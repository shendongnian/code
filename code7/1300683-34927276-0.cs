    // ExtensionsSystem.cs, your handy system-like extensions
    using UnityEngine;
    using System.Collections.Generic;
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    
    public static class ExtensionsSystem
    	{
    	public static List<string> CleanLines(this string stringFromFile)
    		{
    		List<string> result = new List<string>(
    			stringFromFile
    			.Split(new string[] { "\r","\n" },
    				StringSplitOptions.RemoveEmptyEntries)
    			);
    		
    		result = result
    			.Where(line => !(line.StartsWith("//")
    							|| line.StartsWith("#")))
    			.ToList();
    		
    		return result;
    		}
    	}
