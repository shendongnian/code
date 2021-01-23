    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication3
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                const string input = @"[Testing.User]|Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
                const string pattern = @"(\[Testing\.User\])\|(Info:.*)\|(Description:.*)";
    
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    for (int i = 1; i < match.Groups.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] = " + match.Groups[i]);
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
