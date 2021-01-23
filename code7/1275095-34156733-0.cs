    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test1 = "(something)...keepThisOne";
                string test2 = "keepThisOne...(something)";
                string test3 = "(something)...keepThisOne...(somethingelse)";
    
                string testx = "(something)...keepThisOne...(somethingelse)";
    
                Regex rgx = new Regex(@"(?:\([^()]*\))?\.{3}(?:\([^()]*\))?");
                string replacement = "";
                string result = rgx.Replace(testx, replacement);
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }
