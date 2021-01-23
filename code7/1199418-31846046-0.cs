    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<string> data = new List<string>()
    		{
    			"Cisco 10 001c.aabb.ccdd Gi0/50",
    			"HP 001caa-bbccdd 50 10",
    		 	"Other 00:1c:aa:bb:cc:dd 50"
    		};
    		
    		foreach (string strLineBuf in data)
    		{
    			// Finds valid MAC addresses with space before and after
    			Regex rex = new Regex(@"^.* (([0-9A-F]{2}[:.-]?){5}[0-9A-F]{2}\s?).*$", RegexOptions.IgnoreCase);
    			Match m = rex.Match(strLineBuf);
    			if (m.Success)
    			{
    				Console.WriteLine(strLineBuf.Replace(m.Groups[1].Value, String.Empty));
    			}
    		}
    	}
    }
