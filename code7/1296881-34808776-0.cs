    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
     
    public class Test
    {
        public static void Main()
        {
            var input = "The Quick Brown Fox Jumps";
     
            var regex = new Regex(@"(?<=(?<v>\w+)\s+)(?<v>\w+)");
            foreach (var match in regex.Matches(input).Cast<Match>())
            {
                var value = string.Join(" ", match.Groups["v"].Captures.Cast<Capture>().Select(x => x.Value));
     
                Console.WriteLine(value);
            }
        }
    }
