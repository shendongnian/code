    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Regex rgx = new Regex(@"…*\.*\(\w*\)\.*…*");
            Console.WriteLine(rgx.Replace("(something)…keepThisOne", string.Empty));
    		Console.WriteLine(rgx.Replace("keepThisOne…(something)", string.Empty));
    		Console.WriteLine(rgx.Replace("(something)...keepThisOne…(somethingelse)", string.Empty));
    
    	}
    }
