    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
            foreach (var item in GetValues("(John, 36, Alabama, Whatever, Manager)"))
            {
                Console.WriteLine(item);
            }
    	}
    	
    	private static IEnumerable<string> GetValues(string value)
        {
           var matches = Regex.Matches(value, @"\(.*\)");
           if (matches.Count == 0) return new string[0];
    
           var valueSplit = matches[0].Value;
           var theString = valueSplit.Trim('(', ')');
    		var wordSplit = theString.Split(new char[]{','}, 3, StringSplitOptions.None).Select(x=>x.Trim());
           return wordSplit;
        } 
    }
