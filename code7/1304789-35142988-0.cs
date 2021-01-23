    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    public class DictionaryTest
    {
        public static void Main()
        {
            var cache = new Dictionary<int, int>(1000000);
            var sw = Stopwatch.StartNew();
    
            for (var i = 0; i < 1000000; i++)
            {
                lock (cache)
                {
                    int d;
                    if (cache.TryGetValue(i, out d) == false)
                    {
                        cache.Add(i, i);
                    }
                }
            }
    
            sw.Stop();
    
            Console.WriteLine(string.Format("{0}ms", sw.ElapsedMilliseconds));
    
            var sum = 0L;
            foreach (var kvp in cache)
            {
                sum += kvp.Value;
            }
    
            Console.WriteLine("Sum: " + sum);
        }
    }
