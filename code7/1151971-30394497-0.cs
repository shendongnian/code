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
                string input = "some text <trueString> <falseString> some text";
                string pattern = @"(?'beginning'[^\<]+)\<(?'true'[^\>]+)\>\s*<(?'false'[^\>]+)\>(?'ending'[^$]*)";
                Match match = Regex.Match(input, pattern);
                bool condition = true;
                Regex expr = new Regex(pattern);
                string output = "";
                if (condition)
                {
                    output = expr.Replace(input, "${beginning}${true}${ending}");
                }
                else
                {
                    output = expr.Replace(input, "${beginning}${false}${ending}");
                }
            }
        }
    }​
