    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static string[] words = {
            "what", "is", "the", "most", "effecient", "way", "to", "execute", "this", "code"
        };
    
        static void Main(string[] args)
        {
            IEnumerable<string> result;
    
            Console.Write("Choose words order (A to Z (A), Z to A (Z), Reversed (R)): ");
    
            switch (Console.ReadLine().ToUpper())
            {
                case "A": result = words.OrderBy(w => w); break;
                case "Z": result = words.OrderByDescending(w => w); break;
                case "R": result = words.Reverse(); break;
                default: result = words.AsEnumerable(); break;
            }
    
            Console.WriteLine(string.Join(" ", result));
        }
    }
