    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var fruits = new List<Fruit> { new Fruit { ID = 1, Name = "Apple" }, new Fruit { ID = 2, Name = "Apple" }, new Fruit { ID = 3, Name = "Pear" } };	
    		var most = fruits.GroupBy(f => f.Name).OrderByDescending(group => group.Count());
    		Console.WriteLine(most.First().Key);
    	}
    }
    
    public class Fruit
    {
    	public int ID { get; set; }
    	public string Name{ get; set; }
    }
