    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        
        static void Main()
        {
            string big_string = "sabcdaskdeweusdahsabchdjuasdabc";
            string small_string = "abc";
    
            foreach (Match m in Regex.Matches(big_string, small_string))
            {
                Console.WriteLine(m.Index);
            }
    
            Console.Read();
        }
    }
