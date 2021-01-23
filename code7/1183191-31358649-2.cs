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
    		string[] binary = inputBytes.Select(ib => Convert.ToString(ib, 2)).ToArray();
    		Console.WriteLine(String.Join(" ", binary));
    		
    		// Converting bytes back to string
    		Console.WriteLine(ASCIIEncoding.ASCII.GetString(inputBytes, 0, inputBytes.Length));
    		
    		// Binary to ASCII (This is what you're looking for)
    		Console.WriteLine(String.Join("", binary.Select(b => Convert.ToChar(Convert.ToByte(b, 2)))));
    	}
    }
