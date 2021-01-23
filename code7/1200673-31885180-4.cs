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
	    	// The array is typed as int[], not IEnumerable<int>, so the
	        // implicit operator can be used.
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
