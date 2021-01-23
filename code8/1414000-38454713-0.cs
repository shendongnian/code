    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = "1 OR[C2 AND C3] AND C4 OR C5 AND[C6 AND C7 OR C8] OR C9";
                var filtered = Regex.Replace(input, "\\[.*?\\]", string.Empty);
                var result = filtered.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(element => element == "OR" || element == "AND");
                Console.WriteLine(string.Join(", ", result));
                Console.ReadKey();
            }
        }
    }
