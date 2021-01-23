    using System;
    using System.Text.RegularExpressions;
    
    public class RegexTest
    {
        public static void Main(string[] args)
        {
            var sourcestring = @"(Project in (""CI"") and Status in (""Open"") and issueType in (""Action Item"")) or issueKey = ""GR L-1"" order by Created asc";
    
            var mc = Regex.Matches(sourcestring,
                                   @"\(""(?<word>[A-Za-z0-9\s]+)""\)");
    
            foreach (Match m in mc)
            {
                foreach (Capture cap in m.Groups["word"].Captures)
                {
                    Console.WriteLine(cap.Value);
                }
            }
    
            Console.ReadLine();
        }
    }
