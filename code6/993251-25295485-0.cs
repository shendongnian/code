    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        public static void Main(string[] args)
        {
            // Do you want this to be valid or not?
            Console.WriteLine(IsOctal(""));
            Console.WriteLine(IsOctal("012"));
            Console.WriteLine(IsOctal("890"));
            Console.WriteLine(IsOctal("abc"));
            // Do you want this to be valid or not?
            Console.WriteLine(IsOctal("-0123"));
        }
        
        private static bool IsOctal(string text)
        {
            return Regex.IsMatch(text, "^[0-7]+$");
        }
    }
