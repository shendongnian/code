    using System;
    using System.Globalization;
    namespace StackOverflow_31111668
    {
        class Program
        {
            static void Main()
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    var a = Console.ReadLine();
                    int number;
                    Console.WriteLine(!int.TryParse(a, out number) ? "I only accept int" : number.ToString(CultureInfo.InvariantCulture));
                }
            }
        }
    }
