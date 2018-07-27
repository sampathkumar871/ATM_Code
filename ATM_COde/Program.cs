using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_COde
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the Amount you need.");
            string amount = Console.ReadLine();
            string notes = calculateTheDenominations(amount);
            switch (notes)
            {
                case "Invalid Amount":
                    Console.WriteLine("Invalid Amount");
                    break;
                case "Exception":
                    Console.WriteLine("We regrate for the inconvineance caused! we are facing some technical exception!. Please contact bank if amount is deducted from account!");
                    break;
                case "Limit":
                    Console.WriteLine("Max Limit reached! Please try with lesser amount");
                    break;
                default:
                    Console.WriteLine("Please collect the notes from dispenser! Amount Dispensed in following order! Make sure its proper.");
                    Console.WriteLine(notes);
                    break;
            }
            Console.ReadLine();
        }

        private static string calculateTheDenominations(string amount)
        {
            string notes = string.Empty;
            int fivehund, hund, fifty, ten, five = 0;
            try
            {
                try
                {
                    int requestedAmount = Convert.ToInt32(amount);
                    if (requestedAmount <= 25000)
                    {


                        if (requestedAmount % 5 == 0)
                        {
                            fivehund = requestedAmount / 500;
                            if (fivehund > 0)
                            {
                                requestedAmount -= (fivehund * 500);
                            }
                            hund = requestedAmount / 100;
                            if (hund > 0)
                            {
                                requestedAmount -= (hund * 100);
                            }
                            fifty = requestedAmount / 50;
                            if (fifty > 0)
                            {
                                requestedAmount -= (fifty * 50);
                            }
                            ten = requestedAmount / 10;
                            if (ten > 0)
                            {
                                requestedAmount -= (ten * 10);
                            }
                            five = requestedAmount / 5;
                            if (five > 0)
                            {
                                requestedAmount -= (five * 5);
                            }
                            else if (requestedAmount > 0)
                            {
                                return notes = "Invalid Amount";
                            }
                            notes = "500*" + fivehund + "|" + "100*" + hund + "|" + "50*" + fifty + "|" + "10*" + ten + "|" + "5*" + five;
                        }
                        else
                        {
                            return notes = "Invalid Amount";
                        }
                    }
                    else
                    {
                        return notes = "Limit";
                    }
                }
                catch (Exception)
                {
                    return notes = "Invalid Amount";
                }

            }
            catch (Exception ex)
            {
                return notes = "Exception";
            }
            return notes;
        }
    }
}
