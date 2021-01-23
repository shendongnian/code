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
                Regex RegexObj = new Regex("\\(?\\d{3}-?\\)?\\s*\\d{3}-?\\s*-?\\d{4}");
                String Str1 = "(111) 111-1111";
                String Str2 = "111-111-1111";
                String Str3 = "1111111111";
                Console.Write(RegexObj.IsMatch(Str1).ToString() + '\n');
                Console.Write(RegexObj.IsMatch(Str2).ToString() + '\n');
                Console.Write(RegexObj.IsMatch(Str3).ToString() + '\n');
       
              
                Console.Read();
            }
        }
    }
