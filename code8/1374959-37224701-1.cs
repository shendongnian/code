    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string text = File.ReadAllText("f.txt");
            text = Regex.Replace(text, @"\\x[0-9a-fA-Z]{2}", ConvertHexEscape);
            JObject obj = JObject.Parse(text);
            Console.WriteLine(obj);
        }
        
        static string ConvertHexEscape(Match match)
        {
            string hex = match.Value.Substring(2);
            char c = (char) Convert.ToInt32(hex, 16);
            // Now we know the character we're trying to represent,
            // escape it if necessary.
            switch (c)
            {
                case '\\': return @"\\";
                case '"': return "\\\"";
                default: return c.ToString();
            }
        }
    }
