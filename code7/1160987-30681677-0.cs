    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                   "1 Hey, how are u\n" +
                   "\n" +
                   "2 I'm fine thanks\n" +
                   "\n" +
                   "3 Sounds great";
                string pattern = @"^(?'index'\d+)\s+(?'value'.*)";
                Regex expr = new Regex(pattern, RegexOptions.Multiline);
                MatchCollection matches = expr.Matches(input);
                Dictionary<int, string> dict = new Dictionary<int, string>();
                foreach(Match match in matches)
                {
                    dict.Add(int.Parse(match.Groups["index"].Value), match.Groups["value"].Value); 
                }
                string sentence2 = dict[2];
            }
        }
    }
    ​
