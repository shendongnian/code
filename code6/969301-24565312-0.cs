    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		var line = "stackoverflow";
    		//               ^  ^
    		//               a  b
    		
    		var firstIndex = 5;  // a
    		var lastIndex = 8;   // b
    		
    		// Extracts "stack".
    		string str1 = (firstIndex > 0)
            	? line.Substring(0, firstIndex) : string.Empty;
              
            // Extracts "flow".
            string str3 = (lastIndex < line.Length - 1)
        		? line.Substring(lastIndex + 1) : string.Empty;
        		
        	Console.WriteLine("first: [{0}]\nlast[{1}]\n", str1, str3);
    	}
    }
