    using System;
    using System.Text;
					
    public class Program
    {
    	public static void Main()
    	{
    		var sb = new StringBuilder();
    		sb.Append("abc\0def");
    		
    		Console.WriteLine(sb.ToString());
    		var myArray = sb.ToString().Split('\0');
    		
    		Console.WriteLine("myArray.Length " + myArray.Length);
    		foreach(var a in myArray)
    		{
    			Console.WriteLine(a);
    		}
    	}
    }
