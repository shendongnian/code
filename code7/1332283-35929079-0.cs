    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var conflicts = new List<Tuple<string, string>>();
    		conflicts.Add(new Tuple<string, string>("Maths", "English"));
    		conflicts.Add(new Tuple<string, string>("Science", "French"));
    		conflicts.Add(new Tuple<string, string>("French", "Science"));
    		conflicts.Add(new Tuple<string, string>("English", "Maths"));
    		
    		RemoveDupes(conflicts);
    		
    		
    	}
    	
    	public static void RemoveDupes(List<Tuple<string, string>> collection){
    		var duplicates = collection
    			.Select((x, i) => new{ Item= new Tuple<string,string>(x.Item2.IsGreaterThan(x.Item1) ? x.Item2 : x.Item1, 
    																  x.Item2.IsGreaterThan(x.Item1) ? x.Item1 : x.Item2), Index = i})
    			.GroupBy(x => x.Item)
                .Where(x => x.Count() > 1)
    			.Select(x => x.First().Index);
    		foreach(var index in duplicates){
    			collection.RemoveAt(index);
    		}
    	}
    	
    	
    }
    
    public static class Ext{
    	public static bool IsGreaterThan(this string val, string compare){
    		return val.CompareTo(compare) == 1;
    	}
    }
