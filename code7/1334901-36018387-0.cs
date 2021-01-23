    using System.Collections.Generic;
    using System;
    using System.Text.RegularExpressions;
    namespace TestRegex
    {
        class Program
        {
            public static IEnumerable<string> Parse(string input, string startTag, string endTag)
            {
                Regex r = new Regex(Regex.Escape(startTag) + "(.*?)" + Regex.Escape(endTag));
                MatchCollection matches = r.Matches(input);
                foreach (Match match in matches)
                    yield return match.Groups[1].Value;
            }
            static void Main(string[] args)
            {
                var input = " *****.********* start *****.********* aaaaaaaaaaaaaaa adddddddddddddddd dddddddddddddd end *****.********* start *****.********* frfrffrfrffr bbbbbbbbbbbbbbb gggggggggggggggg end *****.********* start *****.********* ppppppppppwpw hhhhheeehheee mmmmmmmmmmeem end ";
                var start = " *****.********* start *****.********* ";
                var end = " end";
                var temp = Parse(input, start, end);
                foreach(var s in temp)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
        }
    }
