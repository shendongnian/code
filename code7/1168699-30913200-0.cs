    using System;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                double first = askForNumber("What is the first number? ");
                Console.WriteLine();
                double second = askForNumber("What is the second number? ");
                Console.WriteLine("\nYou entered {0} and {1}", first, second);
            }
            private static double askForNumber(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    double result;
                    if (double.TryParse(Console.ReadLine(), out result))
                        return result;
                    Console.Beep();
                    Console.WriteLine("\nYou have entered an invalid number!\n");
                }
            }
        }
    }
