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
                Regex regex;
                foreach (string s in args)
                {
                    //Search for the 1st occurrence of the "*.py" pattern
                    regex = new Regex(@"(?s:.*)\056py", RegexOptions.IgnoreCase);
                    bFileExtFlag = regex.IsMatch(s);
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
    
    
        }
    }
