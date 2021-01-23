    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int sin = 0;
    		
    		Console.Write("Please enter sin number: ");
    		string input = Console.ReadLine();
    		while(input.Length != 9 || !int.TryParse(input, out sin) || (sin < 100000000 || sin > 999999999))
    		{
    			Console.WriteLine("Error invalid entry!");
    			Console.WriteLine("");
    			
    			Console.Write("Please enter sin number: ");
    			input = Console.ReadLine();
    		}
    		
    		Console.WriteLine("Entered number: {0}", sin);
    	}
    }
