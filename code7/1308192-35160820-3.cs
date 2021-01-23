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
    		
            string all = "All: " + string.Join(" + ", sequence);
            string even = "Even: " + string.Join(" + ", sequence.Where(a => a % 2 == 0));
            string odd = "Odd: " + string.Join(" + ", sequence.Where(a => a % 2 == 1));
            Console.WriteLine(all + " = " + sequence.Sum());
            Console.WriteLine(even + " = " + sequence.Where(a => a % 2 == 0).Sum());
            Console.WriteLine(odd + " = " + sequence.Where(a => a % 2 == 1).Sum());
    	}
    }
