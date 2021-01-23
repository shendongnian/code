    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;
    public class Test
    {
    	public static void Main()
    	{
            var input = "StartTest\n  NoInclude\nEndTest\n\nStartTest\n  Include\nEndTest";
            var regex = new Regex(@"(?s)StartTest(?:(?!(?:Start|End)Test|NoInclude).)*EndTest");
            var results = regex.Matches(input).Cast<Match>()
                           .Select(p => p.Value)
                           .ToList();
            Console.WriteLine(string.Join("\n", results));
        }
    }
