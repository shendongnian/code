    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = "[0-1]?[0-9]/[0-9]{2}/[0-9]{4}";
            string input = "Due Date: 01/26/2016 Date: 01/25/2016";
    
            foreach (var m in Regex.Matches(input, pattern)) {
                Console.WriteLine("'{0}' found at index {1}.", 
                           m.Value, m.Index);
            }
        }
    }
