    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                string pattern = @"\('(?'steam'[^']*)";
                MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Singleline);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups["steam"]);
                }
                Console.ReadLine();
            }
        }
    }
    ​
