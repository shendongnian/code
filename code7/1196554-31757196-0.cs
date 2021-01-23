    using System;
    using System.Linq;
    
    namespace SumAndAverage
    {
        class Program
        {
            static void Main(string[] args)
            {
                var data = Enumerable.Range(1, 100);
                Console.WriteLine("the sum is " + data.Sum());
                Console.WriteLine("the average is " + data.Average());
            }
        }
    }
