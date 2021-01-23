    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.Write("Min: ");
    		int min = int.Parse(Console.ReadLine()); 
    		Console.Write("Max: ");
    		int max = int.Parse(Console.ReadLine());
    		
    		var sequence = Enumerable.Range(min, max - min + 1);
    		
    		string all = "All: " + string.Join(" + " , sequence.Select(a => a.ToString()));
    		string even = "Even: " + string.Join(" + ", sequence.Where(a => a % 2 == 0).Select(a => a.ToString()));
    		string odd = "Odd: " + string.Join(" + ", sequence.Range(min,max-min+1).Where(a => a % 2 == 1).Select(a => a.ToString()));
    
    		Console.WriteLine(all + " = " + sequence.Sum());
    		Console.WriteLine(even + " = " + sequence.Where(a => a%2==0).Sum());
    		Console.WriteLine(odd + " = " + sequence.Where(a => a%2==1).Sum());
    	}
    }
