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
                    "<td class=\"name\"><a href=\"a\">s</a>" +
                    "<td class=\"name\"><a href=\"b\">t</a>" +
                    "<td class=\"name\"><a href=\"c\">u</a>" +
                    "<td class=\"name\"><a href=\"d\">v</a>" +
                    "<td class=\"name\"><a href=\"e\">w</a>" +
                    "<td class=\"name\"><a href=\"f\">x</a>" +
                    "<td class=\"name\"><a href=\"g\">y</a>" +
                    "<td class=\"name\"><a href=\"h\">z</a>";
                 string pattern = @"href=[^>]*>(?'name'[^<]*)";
                 MatchCollection matches = Regex.Matches(input, pattern);
                 foreach (Match match in matches)
                 {
                     string name = match.Groups["name"].Value;
                     Console.WriteLine(name);
                 }
                 Console.ReadLine();
            }
        }
    }
