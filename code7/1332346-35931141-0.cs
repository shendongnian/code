    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<string> history = new List<string>(){ "AA", "BB", "CC", "AA" };
    		List<string> potentialNew = new List<string>(){ "CC", "AA", "DD", "EE", "FF" };
    		// make lists equal length
    		
    		foreach(var x in history.ConcatOverlap(potentialNew)){
    			Console.WriteLine(x);
    		}
    	}
    	
    	
    }
    
    public static class Ext{
    	public static IEnumerable<string> ConcatOverlap(this List<string> history, List<string> potentialNew){
    		var hleng = history.Count();
    		var pleng = potentialNew.Count();
    		if(pleng > hleng) history = history.Concat(Enumerable.Range(1, pleng - hleng).Select(x => string.Empty)).ToList();
    		if(hleng > pleng) potentialNew = Enumerable.Range(1, hleng - pleng).Select(x => string.Empty).Concat(potentialNew).ToList();
    		
    		
    		var zipped = history.Zip(potentialNew, (a,b)=> new {First=a,Next=b, Equal = (a.Equals(b) || string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))});
    		var count = 0;
    		var max = pleng > hleng ? pleng : hleng;
    		Console.WriteLine("Max " + max);
    		while(zipped.Any(x => !x.Equal) && count < max - 1){
    			count++;
    			potentialNew.Insert(0,string.Empty);
    			history.Add(string.Empty);
    			zipped = history.Zip(potentialNew, (a,b)=> new {First=a,Next=b, Equal = (a.Equals(b) || string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))});
    		}
    		return zipped.Select(x => string.IsNullOrEmpty(x.First) ? x.Next : x.First);
    	}
    }
