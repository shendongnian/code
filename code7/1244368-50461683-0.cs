    using System;
    
    namespace mysCode
    {
        class Program
        {
            static double euclideanDistance(double x1, double y1, double x2, double y2)
            {
                double dX = x2 - x1;
                double dY = y2 - y1;
                return Math.Sqrt(dX * dX + dY * dY);
            }
    
            static void Main(string[] args)
            {
                double n;            
                double c = 0.0;
                double x = 0.0, y = 0.0;
                double result;
                string input;
                Console.WriteLine("Quick, pick an integer");
                input = Console.ReadLine();
                n = double.Parse(input);
                Random rand = new Random();
                for (int i = 1; i <= n; i++)
                {
                    x = rand.NextDouble();
                    y = rand.NextDouble();
                    if (euclideanDistance(x, y, 0, 0) <= 1)
                        c++;
                    result = 4.0 * (c / i);                
                    Console.WriteLine("Result: " + result);
                }
                Console.ReadKey();
            }
    
        }
    }
