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
                string input = "45-78";
                string pattern = @"\d+-\d+";
                Boolean match = Regex.IsMatch(input, pattern);
            }
        }
    }
