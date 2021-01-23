    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            string strMacRegEx = @"(?=.*\d)(?=.*[a-f])[\da-f]{12}";
            string strName = "944a0c112129";
            bool test = Regex.IsMatch(strName, strMacRegEx, RegexOptions.IgnoreCase);
            if (test)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");  // Returns Fail  
            }
        }
    }
