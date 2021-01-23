    using System;
    using System.Collections.Generic;
    
    namespace ListOfArrays
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<string[]> list = new List<string[]>();
    			list.Add( new string[] { "1", "2" } );
    			list.Add( new string[] { "3", "4" } );
    
    			foreach (string[] match in list)
    			{
    				Console.WriteLine(match[0] + match[1]);
    			}
    		}
    	}
    }
