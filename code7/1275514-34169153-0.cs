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
                string input = "CS5999-1";
                MatchEvaluator evaluator = new MatchEvaluator(Replace);
                string results = Regex.Replace(input, "[A-Za-z\\-]", evaluator); 
            }
            static string Replace(Match match)
            {
                if (match.Value == "-")
                {
                    return "";
                }
                else
                {
                    byte[] ascii = Encoding.UTF8.GetBytes(match.Value);
                    return ascii[0].ToString();
                }
            }
        }
    }
    ​
