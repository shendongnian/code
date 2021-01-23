    using System;
    using System.Linq;
    using System.Text;
    
    public class Program
    {
    	public static void Main()
    	{
    		string input = "hello world";
    		byte[] inputBytes = ASCIIEncoding.ASCII.GetBytes(input);
    		
    		// Decimal display
    		Console.WriteLine(String.Join(" ", inputBytes));
    		
    		// Hex display
    		Console.WriteLine(String.Join(" ", inputBytes.Select(ib => ib.ToString("X2"))));
    		
    		// Binary display
    		Console.WriteLine(String.Join(" ", inputBytes.Select(ib => Convert.ToString(ib, 2))));
    		
    		// Converting bytes back to string
    		Console.WriteLine(ASCIIEncoding.ASCII.GetString(inputBytes));
    	}
    }
