    using System;
    using System.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string name = "Jesse";
            int courseNum = 230;
            int num = 23130;
            decimal d = 123456789.54321M;
    
            string combined = name + courseNum + num + d;
    		
    		// Translate ASCII to binary
    		StringBuilder sb = new StringBuilder();
    		foreach (char c in combined)
    		{
    			sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
    		}
    		
    		string binary = sb.ToString();
    		Console.WriteLine(binary);
    		
    		// Translate binary to ASCII
    		StringBuilder decodedBinary = new StringBuilder();
    		for (int i = 0; i < binary.Length; i += 8) 
    		{
    			decodedBinary.Append(Convert.ToChar(Convert.ToByte(binary.Substring(i, 8), 2)));
    		}
    		Console.WriteLine(decodedBinary);
    	}
    }
