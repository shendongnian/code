	using System;
	using System.Collections.Generic;
	
	public class Wrapper<T>
	{
	    public T Val { get; private set; }
	
	    public Wrapper(T val)
	    {
	        Val = val;
	    }
	
	    public static implicit operator Wrapper<T>(T val)
	    {
	        return new Wrapper<T>(val); 
	    }
	}
	
	public class Test
	{
	    public static Wrapper<IEnumerable<int>> GetIt()
	    {
	    	// Storing in a local variable causes the issue.
	    	//IEnumerable<int> a = new int[] { 1, 2, 3 };
	        //return a;
	        return new int[] { 1, 2, 3 };
	    }
	
	    public static void Main()
	    {
	        // Prints 1, 2, 3
	        foreach (var i in GetIt().Val)
	        {
	            Console.WriteLine(i);
	        }
	    }
	}
