    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int sin = 0;
    		string input = "";
    		
    		while(input.Length != 9 || !int.TryParse(input, out sin) || (sin < 100000000 || sin > 999999999))
    		{
    			Console.Write("Please enter sin number: ");
    			input = Console.ReadLine();
    		}
    		
    		Console.WriteLine("Entered number: {0}", sin);
    	}
    }
