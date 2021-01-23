    using System;
    using System.Linq;		
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		string str="Y,J,A,F,L,R,G";
    		string[] arr=str.Split(',');
    		string[]  x=new String[2]{"G","r"};
    		
    		IEnumerable<String> x1=arr.Intersect(x);
    		if(x1.Any())
    		{
    			foreach(string st in x1)
    			{
    				Console.WriteLine("Matched String: "+st);
    			}
    		}
    		else
    		{
    			Console.WriteLine("Empty Matching");
    		}
    		
    	}
    }
