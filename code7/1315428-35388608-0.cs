    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    
    public class Solution
    {
        static void Main()
        {
            const int totalItems = 1000000;
    
            var rng = new Random();
            var foo = Enumerable.Range(0, totalItems).Select(x => rng.Next(1, totalItems / 2)).ToArray();
            var bar = Enumerable.Range(0, totalItems).Select(x => rng.Next(1, totalItems / 2)).ToArray();
    
            var sw = new Stopwatch();
    
            sw.Start();
            var foobar = new HashSet<int>(foo);
            var inBoth = bar.Count(t => foobar.Contains(t));
            sw.Stop();
            Console.WriteLine(sw.Elapsed + " " + inBoth);
    
            sw.Reset();
    
            sw.Start();
            inBoth = bar.Count(t => foo.Contains(t));
            sw.Stop();
            Console.WriteLine(sw.Elapsed + " " + inBoth);
    
            Console.ReadKey();
        }
    }
