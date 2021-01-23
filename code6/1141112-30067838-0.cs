    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var items = new List<SomeObject> {new SomeObject { Age = 10, Name = "Daniel", Company = "InCycle" },
    										 {new SomeObject { Age = 20, Name = "Not Daniel", Company = "Not InCycle" }
    										 }};
    										 
    		var result = Filter<int>(items, "Age");
    		Console.WriteLine(result.Last());
    
    	}
    	
    	public static IEnumerable<T> Filter<T>(IEnumerable<SomeObject> items, string filterCriteria)
    	{
    		var mappings = new Dictionary<string, Func<IEnumerable<SomeObject>, IEnumerable<T>>>
    		{
    			{ "Age", filterItems => filterItems.Select(item => item.Age).Distinct().Cast<T>() }, 
    			{ "Name", filterItems => filterItems.Select(item => item.Name).Distinct().Cast<T>() }, 
    			{ "Company", filterItems => filterItems.Select(item => item.Company).Distinct().Cast<T>() }
    		};
    		
    		return mappings[filterCriteria](items);
    		
    	}
    }
    
    public class SomeObject
    {
    	public int Age {get;set;}
    	public string Name {get;set;}
    	public string Company {get; set;}
    }
    
     
