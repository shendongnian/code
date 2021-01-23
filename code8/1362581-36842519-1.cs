    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var str = "AB12 (1,2,3 words, 4,5,6,7,8,9)";
    		var pat = @"(?<=^[A-Z]{2}\d{2}\s+\([^()]*)\s*[^,\d]+(?=[^()]*\))";
    		var res = Regex.Replace(str, pat, string.Empty);
    		Console.WriteLine(res);
    	}
    }
