    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string input = "sdjkgjkdgjk<br />asdfsdg";
            string pattern = "<br.*\\/>";            // Split on <br/>
    
            DisplayByRegex(input, pattern);
            input = "sdjkgjkdgjk<br style=\"someAttribute: someProperty;\"/>asdfsdg";
            DisplayByRegex(input, pattern);
            Console.Read();
        }
    
        private static void DisplayByRegex(string input, string pattern)
        {
            string[] substrings = Regex.Split(input, pattern);
            foreach (string match in substrings)
            {
                Console.WriteLine("'{0}'", match);
            }
        }
    }
