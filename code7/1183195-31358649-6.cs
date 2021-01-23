    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		string input = "1101000 1100101 1101100 1101100 1101111 100000 1110111 1101111 1110010 1101100 1100100";
    		string[] binary = input.Split(' ');
    		
    		Console.WriteLine(String.Join("", binary.Select(b => Convert.ToChar(Convert.ToByte(b, 2))).ToArray()));
    	}
    }
