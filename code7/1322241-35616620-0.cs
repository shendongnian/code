    using System;
    
    namespace ArraySort
    {
    	class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			var Color = new String[5];
    
    			Color[0] = "Orange";
    			Color[1] = "Blue";
    			Color[2] = "Purple";
    			Color[3] = "Green";
    			Color[4] = "Red";
    
    			Array.Sort(Color); //Error: The type or namespace name 'Sort' does not exist in namespace 'Array'. Are you missing an assembly reference?
    
    			Console.WriteLine ("Colors:");
    
    			foreach(string s in Color)
    			{
    				Console.WriteLine (s);
    			}
    		}
    	}
    }
