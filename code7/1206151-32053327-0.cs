    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var arr = new Dictionary<char, int> {
                {'N', 1},
                {'M', 2},
                {'P', 3},
            };
            
            foreach (var pair in arr) {
                System.Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }
    }
