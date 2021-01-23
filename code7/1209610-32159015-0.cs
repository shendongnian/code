    using System;
    
    namespace TrinomialCalculator
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Trinomial Calculator");
                Console.WriteLine("====================");
                GetValues();
                Console.ReadLine();
            }
            static void GetValues()
            {
                Console.WriteLine("ax^2+bx+c");
                Console.WriteLine("=========");
    
                string numInput;
                int[] values = new int[3];
    
                Console.WriteLine("Enter an integer for 'a': ");
                numInput = Console.ReadLine();
                int.TryParse(numInput, out values[0]);
                Console.WriteLine("Enter an integer for 'b': ");
                numInput = Console.ReadLine();
                int.TryParse(numInput, out values[1]);
                Console.WriteLine("Enter an integer for 'c': ");
                numInput = Console.ReadLine();
                int.TryParse(numInput, out values[2]);
    
                if (values[0] == 0 || values[1] == 0 || values[2] == 0)
                {
                    Console.WriteLine("One or more inputs are invalid. Try again.");
                    return;
                }
    
                Console.WriteLine("{0}x^2+{1}x+{2}", values[0], values[1], values[2]);
                DisplayResult(values);
            }
            static double[] DisplayResult(int[] values)
            {
                double[] result = new double[2];
                result[0] = -values[1] + Math.Sqrt(values[1] ^ 2 - 4 * values[0] * values[2]);
                result[1] = -values[1] - Math.Sqrt(values[1] ^ 2 - 4 * values[0] * values[2]);
                Console.WriteLine("X(1)={0}\n X(2)={1}", result[0], result[1]);
                return result;
            }
        }
    }
