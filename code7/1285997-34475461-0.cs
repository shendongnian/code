    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        static void Main()
        {
            List<string> words   = new List<string> { @"\bbooks\b", @"\bbooksellings\b", ... };
            string pattern = string.Join("|", words.Select(w => Regex.Escape(w)));
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }
    }
