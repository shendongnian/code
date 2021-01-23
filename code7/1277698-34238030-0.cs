    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var list = new List<List<C>>{
    			new List<C>{
    				new C(1), 
    				new C(2)
    			}, 
    			new List<C>{
    				new C(3), 
    				new C(4)}
    		};
    		
    		
    		Console.WriteLine((list[0][0]).Value);
    		Console.WriteLine((list[0][1]).Value);
    		Console.WriteLine((list[1][0]).Value);
    		Console.WriteLine((list[1][1]).Value);
    	}
    }
    
    public class C
    {
    	public int Value;
    	
    	public C(int val)
    	{
    		this.Value = val;
    	}
    }
