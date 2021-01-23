    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Program
        {
            private static void Main()
            {
                var pricesByDate = new Dictionary<DateTime, double[]>();
                var date1 = new DateTime(2015, 01, 01);
                var date2 = new DateTime(2015, 01, 02);
                var date3 = new DateTime(2015, 01, 03);
                pricesByDate[date1] = new[] { 1.01, 1.02, 1.03 };
                pricesByDate[date2] = new[] { 2.01, 2.02, 2.03, 2.04 };
                pricesByDate[date3] = new[] { 3.01, 3.02 };
                Console.WriteLine("Prices for {0}:", date2);
                var pricesForDate2 = pricesByDate[date2];
                foreach (double price in pricesForDate2)
                    Console.WriteLine(price);
                Console.WriteLine("\nAll Dates and prices:");
                foreach (var entry in pricesByDate)
                {
                    Console.Write("Prices for {0}: ", entry.Key.ToShortDateString());
                    foreach (double price in entry.Value)
                        Console.Write(price + " ");
                    Console.WriteLine();
                }
            }
        }
    }
