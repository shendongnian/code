    using System;
    namespace Demo
    {
        static class Program
        {
            public static void Main()
            {
                printFormatted("Short", 12.34);
                printFormatted("Medium", 1.34);
                printFormatted("The Longest", 1234.34);
            }
            static void printFormatted(string description, double cost)
            {
                string result = format(description, cost);
                Console.WriteLine(">" + result + "<");
            }
            static string format(string description, double cost)
            {
                return string.Format("{0,15} {1,9:C2}", description, cost);
            }
        }
    }
