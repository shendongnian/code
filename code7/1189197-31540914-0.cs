    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    namespace Demo
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                var array = new int[100000000];
                var sw = new Stopwatch();
                for (int trial = 0; trial < 8; ++trial)
                {
                    sw.Restart();
                    for (int i = 0; i < 10; ++i)
                        max1(array);
                    var elapsed1 = sw.Elapsed;
                    Console.WriteLine("int[] took " + elapsed1);
                
                    sw.Restart();
                    for (int i = 0; i < 10; ++i)
                        max2(array);
                    var elapsed2 = sw.Elapsed;
                    Console.WriteLine("IEnumerable<int> took " + elapsed2);
                    Console.WriteLine("\nFirst method was {0} times faster.\n", elapsed2.TotalSeconds / elapsed1.TotalSeconds);
                }
            }
            private static int max1(int[] array)
            {
                int result = int.MinValue;
                foreach (int n in array)
                    if (n > result)
                        result = n;
                return result;
            }
            private static int max2(IEnumerable<int> array)
            {
                int result = int.MinValue;
                foreach (int n in array)
                    if (n > result)
                        result = n;
                return result;
            }
        }
    }
