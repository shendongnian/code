    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "Test with two:\t\t tab characters";
                string output = Regex.Replace(input, @"(\t+)", "<span class=\"\" style=\"white-space:pre\">$1</span>");
            }
        }
     }
