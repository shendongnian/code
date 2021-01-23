    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("1 + 2 = ?");
    		Console.WriteLine("a: 1");
    		Console.WriteLine("b: 2");
    		Console.WriteLine("c: 3");
    		Console.WriteLine("d: 4");
    		
    		Console.Write("Select answer: ");
    		
    		char ans;
    		do
    		{
    			// Only accept the first character, using .ToLower to ignore casing
    			ans = Console.ReadLine().ToLower()[0];
    			if (ans < 'a' || 'd' < ans)
    			{
    				Console.WriteLine("Please select a, b, c, or d!");
    			}
    		} while (ans < 'a' || 'd' < ans); // This is your clean up
    		
    
    		Console.WriteLine(ans == 'c' ? "You are correct!" : "You are incorrect!");
    	}
    }
