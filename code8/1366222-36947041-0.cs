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
                string input = "1 Johannes 1:3, 2 Johannes 2:6, 1 Mosebok 5:4";
                string pattern = @"(?'index'\d+)\s+(?'name'\w+)\s+(?'para'\d+:\d+),?";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    Console.WriteLine("index : {0}, name : {1}, para : {2}",
                        match.Groups["index"],
                        match.Groups["name"],
                        match.Groups["para"]
                    );
                }
                Console.ReadLine();
            }
        }
    }
