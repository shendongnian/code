    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	string  = "Showing: 16 of 11543 course results";
	Match match = Regex.Match(input, @"Showing: (\d{1,10}) of (\d{1,10}) course results", RegexOptions.IgnoreCase);
	if (match.Success)
	{
	   
	    string firstNum = match.Groups[1].Value;
