    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string decode = "8421";
                string input = "3c8080080040040020020010010000000000000000003c";
                DateTime sunday = DateTime.Parse("4/3/2016");
                for (int dayIndex = 0; dayIndex < 7; dayIndex++)
                {
                    for (int fourHourIndex = 0; fourHourIndex < 6; fourHourIndex++)
                    {
                        if (input.Substring((6 * dayIndex) + fourHourIndex + 2, 1) != "0")
                        {
                            DateTime tempDate = sunday.AddDays(dayIndex).AddHours((4 * fourHourIndex) + decode.IndexOf(input.Substring((6 * dayIndex) + fourHourIndex + 2, 1)));
                            Console.WriteLine(tempDate.ToString());
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
