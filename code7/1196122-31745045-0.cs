    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
    
                var lines = new List<string[]>
                {
                    new[] { "That", "is", "a", "cat" },
                    new[] { "That", "bat", "flew", "over", "the", "cat" }
                };
    
                var distinctWords = lines.SelectMany(strings => strings.AsEnumerable()).Distinct().ToArray();
    
                var result = (
                    from line in lines
                    let lineWords = line.ToArray()
                    let counts = distinctWords.Select(distinctWord => lineWords.Contains(distinctWord) ? 1 : 0).ToArray()
                    select new Tuple<string[], int[]>(distinctWords, counts)
                ).ToList();
            }
        }
    }
