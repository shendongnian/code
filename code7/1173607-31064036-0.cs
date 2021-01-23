    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<Flavor> availableFlavors = new List<Flavor> () {
    			new Flavor() { ID = 1, Name = "Vanilla" },
    			new Flavor() { ID = 2, Name = "Chocolate" },
    			new Flavor() { ID = 3, Name = "Strawberry" },
    			new Flavor() { ID = 4, Name = "Rocky Road" },
    			new Flavor() { ID = 5, Name = "Cookies and Cream"}
    		};
    		
    		List<Flavor> favoriteFlavors = new List<Flavor>() {
    			new Flavor() { ID = 1, Name = "Vanilla" },
    			new Flavor() { ID = 3, Name = "Strawberry" },
    		};
    		
    		availableFlavors.Where(f => !favoriteFlavors.Contains(f))
    			.ToList()
    			.ForEach(f => Console.WriteLine(f));
    	}
    }
    
    public class Flavor
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    	
    	public override bool Equals(object obj)
    	{
    		Flavor objToCheck = obj as Flavor;
    		if (objToCheck != null)
    		{
    			if (objToCheck.ID == ID &&
    				objToCheck.Name == Name)
    			{
    				return true;
    			}
    			return false;
    		}
    		return false;
    	}
    	
    	public override string ToString()
    	{
    		return String.Format("ID: {0} Name: {1}", ID, Name);
    	}
    }
