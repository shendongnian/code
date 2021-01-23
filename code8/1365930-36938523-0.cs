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
                string test1 = "255\r\n\r\n0\r\n\r\n-1\r\n\r\n255\r\n\r\n1\r";
                string test2 = @"255\r\n\r\n0\r\n\r\n-1\r\n\r\n255\r\n\r\n1\r";
                Console.WriteLine("First String");
                MatchCollection matches = Regex.Matches(test1, @"\d+", RegexOptions.Singleline);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
                Console.WriteLine("Second String");
                matches = Regex.Matches(test2, @"\d+", RegexOptions.Singleline);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
                Console.ReadLine();
            }
        }
    }
