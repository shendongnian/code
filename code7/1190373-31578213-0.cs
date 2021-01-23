    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Program
    {
    	public static void Main()
    	{
    	
    		Console.WriteLine("Give some numbers");
    		string n = Console.ReadLine();
    		int sum = 0;
    		
    		foreach(var i in n.Split(' ')){
    			sum += int.Parse(i);
    		}
    			
    		Console.Write("the sum of your numbers is: {0} ", sum);		
    	}
    }
