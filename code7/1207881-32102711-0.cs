    using System;
    using System.Text;
    
    public class Test
    {
    	public static void Main()
    	{
    		Int32 value = 5152;
    		byte[] bytes = new byte[4];
    		for (int i = 0; i < 4; i++)
    		{
    			bytes[i] = (byte)((value >> i * 8) & 0xFF);
    		}
    		
    		StringBuilder result = new StringBuilder();
    		for (int i = 0; i < 4; i++)
    		{
    			result.Append("\\" + bytes[i].ToString("X2"));
    		}
    		
    		Console.WriteLine(result);
    	}
    }
