    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "0,,,,,,,1,,2,3,,,,5";
                string fstr = "";
               Regex RegExp = new Regex(@"\d,?");
               MatchCollection matches = RegExp.Matches(str);
               foreach (Match match in matches) 
               {
                   fstr = fstr + match.ToString();
               }
    
                Console.Write(fstr);
                Console.Read();
            }
        }
    }
