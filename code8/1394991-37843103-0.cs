    using System.Text.RegularExpressions;
    ...
            var str = "1A1234ABCD12345678";
            var regex = new Regex(@"(^.*?)(\d*)$");
            if (regex.IsMatch(str))
            {
                var matches = regex.Matches(str);
                for (int a = 0; a < matches.Count; a++)
                {
                    var match = matches[a];
                    for (int b = 0; b < match.Groups.Count; b++)
                    {
                        Console.WriteLine("Match{0}Group{1}:{2}", a, b, match.Groups[b].Value);
                    }
                }
                Console.WriteLine("Answer: {0} {1}", matches[0].Groups[1], matches[0].Groups[2]);
            }
            Console.ReadLine();
