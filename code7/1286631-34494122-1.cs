    using System;
    using System.Text.RegularExpressions;
					
    public class Program
     {
    	public static void Main()
    	{
    		var equivalentSentence = "[[at the Location ]] [[Location at]] [[Location]]";		
		
    		Regex regex = new Regex(@"\[\[(?<location>(.*?)) \]\]");
    		Match match = regex.Match(equivalentSentence);
		
    		if (match.Success)
    		{
    			var location = match.Groups["location"].Value;
    			Console.WriteLine(location);
    		}
    	}
    }
