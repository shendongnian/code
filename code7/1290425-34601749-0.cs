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
                string input = "Environment.Exit(0);" +
                               "Environment.Exit(0);";
                string output = Regex.Replace(input, @"Environment.Exit\(0\);", new MatchEvaluator(MyReplacement));
            }   
            static int count = 1;
            static string MyReplacement(Match match)
            {
                return string.Format("File.WriteAllText(\"code\",{0}); Environment.Exit(0);", count++); 
            }
        }
    }​
