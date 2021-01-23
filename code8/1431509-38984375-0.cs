    using System;
    using System.Linq;
    using System.Text;
					
    public class Program
    {
    	public static void Main()
    	{
    		byte[] x = new byte[] { 55,55,55,93,93,0,23,0};
    		var firstNullIndex = Array.FindIndex(x, b => b == 0);
    		
    		string s = Encoding.Default.GetString(x, 0, firstNullIndex);
    		Console.WriteLine(s);
    		
    	}
    }
