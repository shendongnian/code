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
    		foreach(var i in conflicts) Console.WriteLine(i.Item1 + " " + i.Item2);
    		
    	}
    	
    	public static void RemoveDupes(List<Tuple<string, string>> collection){
    		var duplicates = collection
    			// indescriminate which value comes first
    			.Select((x, i) => new{ Item= new Tuple<string,string>(x.Item2.IsGreaterThan(x.Item1) ? x.Item2 : x.Item1, 
    																  x.Item2.IsGreaterThan(x.Item1) ? x.Item1 : x.Item2), Index = i})
    			// group on the now indescrimitate values
    			.GroupBy(x => x.Item)
    			// find duplicates
    			.Where(x => x.Count() > 1)
    			.Select(x => new {Items = x, Count=x.Count()})
    			// select all indexes but first
    			.SelectMany( x =>
    				x.Items.Select( b => b)
    					   .Zip(Enumerable.Range( 1, x.Count ),
    							( j, i ) => new { Item = j, RowNumber = i }
    				)
        		).Where(x => x.RowNumber != 1);
    		foreach(var item in duplicates){
    			collection.RemoveAt(item.Item.Index);
    		}
    	}
    	
    	
    }
    
    public static class Ext{
    	public static bool IsGreaterThan(this string val, string compare){
    		return val.CompareTo(compare) == 1;
    	}
    }
