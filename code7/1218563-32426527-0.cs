    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var fooList = new List<Foo>
    		{
    			new Foo { Id = 20, Value = 200 },
    			new Foo { Id = 20, Value = 300 },
    			new Foo { Id = 10, Value = 100 },
    			new Foo { Id = 10, Value = 050 }
    		};
    		
    		var maxId = fooList.Max(f => f.Id);
    		var maxValue = fooList.Where(f => f.Id == maxId).Max(f => f.Value);
    		
    		Console.WriteLine("Max Id = {0}", maxId);
    		Console.WriteLine("Max value = {0}", maxValue);
    	}
    	
    	public class Foo
    	{
    		public int Id { get; set; }
    		public int Value { get; set; }
    	}
    }
