    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var s = "(Price+Discounted_Price)*2-Max.Price";
    		var dct = new Dictionary<string, string>();
    		dct.Add("Price", "A1");
    		dct.Add("Discounted_Price", "A2");
    		dct.Add("Max.Price","A3");
    		var res = Regex.Replace(s, @"(?<![\w.])[\w.]+(?![\w.])",     // Find all matches with the regex inside s
    			x => dct.ContainsKey(x.Value) ?   // Does the dictionary contain the key that equals the matched text?
                      dct[x.Value] :              // Use the value for the key if it is present to replace current match
                      x.Value);                   // Otherwise, insert the match found back into the result
    		Console.WriteLine(res);
    	}
    }
