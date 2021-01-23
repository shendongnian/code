    using System;
    using System.Collections.Generic;
    namespace Test
    {
        class Program
        {
            public static Dictionary<string, double> Elements = new Dictionary<string, double>
            {
                {"Na",22.990},
                {"Cl",35.453}
            };
            static void Main()
            {
                double result = 0;
                int elemenCountInput;
                do
                {
                    Console.WriteLine("How many elements are in the compound?");
                } while (!Int32.TryParse(Console.ReadLine(), out elemenCountInput));
                for (int i = 0; i < elemenCountInput; i++)
                {  
                    string element;
                    do
                    {
                        Console.WriteLine("What is the {0} element", (i + 1));
                        element = Console.ReadLine();
                    } while (!Elements.ContainsKey(element));
                    int amount;
                    do
                    {
                        Console.WriteLine("How many");
                    } while (!Int32.TryParse(Console.ReadLine(), out amount));
                    result += Elements[element] * amount;
                }
                Console.Write("The Mass is {0}g/mol", result);
                Console.ReadLine();
            }
        }
    }
