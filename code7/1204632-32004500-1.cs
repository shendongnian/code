    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
        	Regex regex = new Regex(@"\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*");
        	Match match = regex.Match("sgsdgsdgs 123-456-7890 sdgsdgs (123) 456-7890 sdgsdgsdg 123 456 7890 sdgsdgsdg 123.456.7890 sdfsdfsdfs +91 (123) 456-7890");
        	List < string > list = new List < string > ();
        	while (match.Success)
        	{
                list.Add(match.Value);
        	    match = match.NextMatch();
        	}
        	list.ForEach(Console.WriteLine);
        }
    }
