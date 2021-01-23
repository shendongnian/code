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
                string input = "[{\"a\":{\"e\":{\"e\":161,\"a\":\"blue\",\"d\":{\"e\":-14,\"a\":\"red\",\"d\":{\"c\":\"yellow\",\"a\":[-35,0],\"b\":\"orange\",\"d\":";
                string pattern = @"[-+]?\d+";
                MatchCollection matches = Regex.Matches(input, pattern);
                List<int> output = new List<int>();
                foreach(Match match in matches)
                {
                    output.Add(int.Parse(match.Value));
                }
            }
        }
    }
    ​
