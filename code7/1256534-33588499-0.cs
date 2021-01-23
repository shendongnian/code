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
                string input = "A = [5 4 1; 3 6 1; 2 3 9]";
                string pattern = @"(?'name'\w+)\s+=\s+\[(?'numbers'[^\]]+)\]";
                Match match = Regex.Match(input, pattern);
                string name = match.Groups["name"].Value;
                string numbers = match.Groups["numbers"].Value;
                List<List<int>> array = numbers.Split(new char[] { ';' }).Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(z => int.Parse(z)).ToList()).ToList();
            }
        }
    }
    ​
