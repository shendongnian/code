    using System;
    using System.Collections.Generic;
    
    namespace Sample
    {
    	public class Item
    	{
    	}
    
    	public class Business : Item
    	{
    	}
    
    	public class Attraction : Item
    	{
    	}
    
    	public class Foo
    	{
    		public List<T> GetItems<T>() where T : Item
    		{
                //TODO: based on T, call the appropriate services to populate the list
    			return new List<T>();
    		}
    	}
    
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			// Examples:
    			var foo = new Foo();
    			List<Attraction> attractions = foo.GetItems<Attraction>();
                List<Business> businesses = foo.GetItems<Business>();
                List<Item> items = foo.GetItems<Item>();
    			//...
    		}
    	}
    }
