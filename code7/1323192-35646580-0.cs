    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var line = "xxx abcdef abcdef xxx zxcvbn zxcvbn xxx poiuy poiuy";
            var splts = Regex.Split(line, @"xxx").Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
            //Console.WriteLine(splts.Count()); // => 3
            foreach (string match in splts)
	        {
	           Console.WriteLine("'{0}'" , match);
    	    }
    }
