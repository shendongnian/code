    using System;
    using System.Text.RegularExpressions;
        
    class Program
    {
        static void Main()
        {
    	    string yourInputString = "Showing: 16 of 11543 course results";
            Match match = Regex.Match(yourInputString, @"Showing: (\d{1,10}) of (\d{1,10}) course results", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string firstNum = match.Groups[1].Value;
                string secondNum = match.Groups[2].Value;
            }
        }
    }
