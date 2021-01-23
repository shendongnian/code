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
                string input = "Jan (10) Anna (100)";
                string pattern = @"\w+\s\(\d+\)";
                MatchCollection matches = Regex.Matches(input,pattern);
                foreach(Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
                Console.ReadLine();
            }
        }
     
    }
    ​
