    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		string Text = "{1}[56](17)(20)(13)(14)[895](11)(20)[3](8)(12)(3)[19](1)(2)(13)(7)(6){2}[99](1)(2)(3)";
    		
    		// Split out pairs
    		// 0: {#}
    		// 1: [#](#)..(n)
    		string[] splits = Regex.Split(Text, "({\\d+})").Where(split => !String.IsNullOrEmpty(split)).ToArray();
    		Dictionary<string, Dictionary<string, List<int>>> items = new Dictionary<string, Dictionary<string, List<int>>>();
    		for (int i = 0; i < splits.Length; i += 2)
    		{
    			// splits[i] is {#} which will make the key for this part of the Dictionary
    			items.Add(splits[i], new Dictionary<string, List<int>>());
    			items[splits[i]] = new Dictionary<string, List<int>>();
    			
    			// Split out sub pairs
    			// 0: [#]
    			// 1: (#)..(n)
    			string[] subSplits = Regex.Split(splits[i + 1], "(\\[\\d+\\])").Where(subSplit => !String.IsNullOrEmpty(subSplit)).ToArray();
    			for (int j = 0; j < subSplits.Length; j += 2)
    			{
    				// subSplits[j] is [#] which will make the key for the inner Dictionary
    				items[splits[i]].Add(subSplits[j], new List<int>());
    				
    				// subSplits[j + 1] is all of the (#) for each [#]
    				//  which we'll add to the List of the inner Dictionary
    				Match m = Regex.Match(subSplits[j + 1], "(\\d+)");
    				while (m.Success)
    				{
    					items[splits[i]][subSplits[j]].Add(Convert.ToInt32(m.Groups[0].ToString()));
    					m = m.NextMatch();
    				}
    			}
    		}
    
    		// Print the keys of the Dictionary, the keys of the inner Dictionary, the values of the inner Dictionary
    		foreach (string key in items.Keys)
    		{
    			Console.WriteLine("Key: {0}", key);
    			foreach (string subKey in items[key].Keys)
    			{
    				Console.WriteLine("\t SubKey: {0}", subKey);
    				Console.WriteLine("\t\t Value: {0}", String.Join(", ", items[key][subKey]));
    			}
    		}
    	}
    }
