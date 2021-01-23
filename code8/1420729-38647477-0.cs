    using System;
    using System.Collections.Generic;
    using System.Linq;
    	
    public class Program
    {
    	public static void Main()
    	{
    		var list = new List<double> { 2.1, 2.2, 4, 4.1, 8, 8.2};
    		var avereges = new List<double>();
    		
    		
    		list.Sort();
    		
    		
    		double sum = list[0], original = list[0], count = 1;
    		
    		
    		for (int i = 1; i < list.Count; i++)
    		{
    
    			if (Math.Abs(original-list[i]) < 0.25)
    			{
    				sum += list[i];
    				count++;
    			}
    			else
    			{
    				avereges.Add(sum/count);
    				count = 1;
    				sum = list[i];
    				original = list[i];
    			}
    		}
    		
    		avereges.Add(sum/count);
    		
    		Console.WriteLine(String.Join(" ", avereges));
    	}
    }
