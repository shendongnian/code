    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var input = "iif(instr(|Wellington, New Zealand|,|,|)>0,|Wellington, New Zealand|,|Wellington, New Zealand| & |, | & |New Zealand|) & | to | & iif(instr(|Jeddah, Saudi Arabia|,|,|)>0,|Jeddah, Saudi Arabia|,|Jeddah, Saudi Arabia| & |, | & |Saudi Arabia|) & iif(|Jeddah, Saudi Arabia|=||,||,| via | & |Jeddah, Saudi Arabia|)";
    		
    		Console.WriteLine(input);
    		
    		var re = new Regex(@"\|.*?\|");
    		
    		var matches = re.Matches(input);
    		
    		var mz = new List<string>();
    		
    		foreach(Match m in matches) 
    		{
    			mz.Add(m.Groups[0].ToString());
    		}
    		
    		var routeMap = mz.Distinct().OrderByDescending(n => n.Length).ToList();	//Get distinct, and sort it longest to shortest... need it this way or it won't do the replacement correctly.
    		
    		for (var i = 0; i < routeMap.Count; i++) 
    		{
    			input = input.Replace(routeMap[i], string.Format("~{0}~", i));			
    		}
    		
    		Console.WriteLine(input);
    		
    		Console.WriteLine();
    		Console.WriteLine("The route map replacement key:");
    		var idx = 0;
    		routeMap.ForEach(m => Console.WriteLine("{0}: {1}", idx++, m));
    		
    	}
    }
