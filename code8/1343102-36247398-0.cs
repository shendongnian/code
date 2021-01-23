    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            Regex regex = new Regex(@"^[0-9]{2}-[0-9]{2}$");
        	Match match = regex.Match("45-55");
        	if (match.Success)
        	{
        	    Console.WriteLine("Verified");
        	}
        }
    }
