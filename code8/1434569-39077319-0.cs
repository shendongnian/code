    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication9
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string[] inputs = {
                                     "9 something 58" ,
                                     "19.58 something"
                                 };
                foreach (string input in inputs)
                {
                    MatchCollection matches = Regex.Matches(input, @"(?'number'\d*\.\d*)|(?'number'\d+[^\.])");
                    foreach (Match match in matches)
                    {
                        Console.WriteLine("Number : {0}", match.Groups["number"].Value);
                    }
                }
                Console.ReadLine();
                
            }
        }
    }
