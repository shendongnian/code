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
    		var res = Regex.Replace(s, @"(?<![\w.])[\w.]+(?![\w.])", 
    			x => dct.ContainsKey(x.Value) ?  dct[x.Value] : x.Value);
    		Console.WriteLine(res);
    	}
    }
