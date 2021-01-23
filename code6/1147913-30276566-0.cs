    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                const long x = 1;
                var numbers = new long[] {3, 7, 1, 29};
                var theSmallestIndex = SmallestIndex(x, numbers);
                stopWatch.Stop();
                Console.WriteLine("Elapsed Time: {0}", stopWatch.Elapsed);
                Console.WriteLine("Smallest Index: {0}", theSmallestIndex);
                Console.ReadKey();
            }
    
            public static long SmallestIndex(long x, long[] numbers)
            {
                var values = ValuesMinusTheValueOfPreviousIndex(x, numbers.ToList());
                var smallest = values.Values.OrderBy(n => n).FirstOrDefault();
                var result = values.Where(n => n.Value.Equals(smallest));
                return result.FirstOrDefault().Key;
            }
    
            public static Dictionary<int, long> ValuesMinusTheValueOfPreviousIndex(long x, List<long> numbers)
            {
                var results = new Dictionary<int, long>();
                foreach (var number in numbers)
                {
                    var index = numbers.IndexOf(number);
                    var previousNumber = index > 0 ? numbers.ElementAt(index - 1) : 0;
                    var result = number - previousNumber;
                    results.Add(index, result);
                }
    
                return results;
            }
        }
    }
