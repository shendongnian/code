    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Linq;	
    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		var itemsA = new[]{new ItemA {Name = "a", Date = DateTime.Now}};
    		var itemsB = new[]{new ItemB {Name = "b" }};
    		
    		
    		var list = (from solution1 in itemsA
                select new
                {
                    Name = solution1.Name,
                    Date = (DateTime?)solution1.Date
                })
            .Union(from solution2 in itemsB
                select new{
                    Name = solution2.Name,
                    Date = (DateTime?)null                
                });
    		
    		Console.WriteLine(list.Count());
    		
    	}
    	public class ItemA
    	{
    		public string Name {get;set;}
    		public DateTime Date {get;set;}
    	}
    	public class ItemB
    	{
    		public string Name {get;set;}
    	
    	}
    	
    }
