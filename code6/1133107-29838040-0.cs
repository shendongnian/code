    using System;
    using System.Collections.Generic;
					
    public class Program
    {
    	public static void Main()
    	{
    		List<String> list = new List<String>();
    		list.Add(@"One\\Two");
    		list.Add(@"Three");
    		list.Add(@"Four");
    		
    		String s = String.Join(@"\\", list.ToArray());
    		
    		Console.WriteLine(s);
    	}
    }
