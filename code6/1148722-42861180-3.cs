    using System;
    using System.Text.RegularExpressions;           //Regex
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string cmdLine = String.Join(" ", args);
    
                bool bFileExtFlag = false;
                int argIndex = 0;
                foreach (string s in args)
                {
                    bFileExtFlag = MatchPyExtensionFileName(s, ".py");
                    if (bFileExtFlag == true)
                        break;
                    argIndex++;
                };
    
                Console.WriteLine("Argument list: " + cmdLine);
                if (bFileExtFlag == true)
                    Console.WriteLine("Found python filename: " + args[argIndex]);
                else
                    Console.WriteLine("Python file with extension <.py> not found!");
            }
    
            private static bool MatchPyExtensionFileName(String s, String wildCardPattern)
            {
                Regex regex;
    
                regex = new Regex(wildCardPattern, RegexOptions.IgnoreCase);
                    return (regex.IsMatch(s));
            }
        }
    }
