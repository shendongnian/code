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
                string input = "FILE = .test\testfile CRC = 0x0987678 DATE = 10/09/2015 VERSION = 1";
                string pattern = @"(?'name'[\w]+)\s+=\s+(?'value'[^\s]+)";
                Regex expr = new Regex(pattern);
                MatchCollection matches = expr.Matches(input);
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (Match match in matches)
                {
                    dict.Add(match.Groups["name"].Value, match.Groups["value"].Value);
                }
            }
        }
    }​
