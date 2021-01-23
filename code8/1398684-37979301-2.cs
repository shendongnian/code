    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Multiple_Replace
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = " ₹ 5000 €";
                var replacements = new Dictionary<string, string> { { "₹", "\u20B9" }, { "&euro;", "&#8364" } };
                var output = replacements.Aggregate(input, (current, replacement) => current.Replace(replacement.Key, replacement.Value));
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
