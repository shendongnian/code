    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var foos = new List<Foo>()
    		{
    			new Foo(true, 1),
    			new Foo(false, 2)
    		};
    		
    		// works
    		var actives = foos.Where(x => x.IsActive=true).ToList();
    		// returns 2, not 1!
    		Console.WriteLine(actives.Count);
    		
    		// compile error
    		var ages = foos.Where(x => x.Age = 1).ToList();
    	}
    }
    
    public class Foo {
    	public Foo(bool active, int age)
    	{
    		this.IsActive = active;
    		this.Age = age;
    	}
    
    	public bool IsActive { get; set; }
    	public int Age { get; set; }
    }
