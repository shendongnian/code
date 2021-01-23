    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var words = new SortedSet<string>(StringComparer.Ordinal)
            {
                "cat", "dog", "banana", "laptop", "mug",
                "coffee", "microphone", "water", "stairs", "phone"
            };
            
            foreach (var word in words.GetViewBetween("d", "n"))
            {
                Console.WriteLine(word); 
            }
        }
    }
