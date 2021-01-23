    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
                var lines = new List<string> { "aaabb", "ccddddd", "efffggggg" };
    
                var result = (
                    from line in lines
                    let matches = Regex.Matches(line, "(.)\\1+").Cast<Match>()
                    let maxLen = matches.Max(match => match.Length)
                    let maxMatch = matches.First(match => match.Length == maxLen)
                    select string.Format("{0},{1}", maxMatch.Value, maxLen)
                ).ToList();
    
                result.ForEach(Console.WriteLine);
            }
        }
    }
