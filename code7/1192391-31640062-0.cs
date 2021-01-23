    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<string> _1000Lines = new List<string>();
    		for (int i = 1; i <= 1000; i++)
    			_1000Lines.Add(i.ToString());
    		
    		for (int i = 0; i < _1000Lines.Count; i += 25) 
    		{
    			// Use Skip() to skip the previous 25 items from the previous iteration
    			Console.WriteLine(String.Join(" ", _1000Lines.Skip(i).Take(25)));
    		}
    	}
    }
