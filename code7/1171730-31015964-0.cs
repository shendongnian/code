    using System;
    using System.Runtime.InteropServices;
    namespace InteropDemo
    {
    	class MainClass
    	{
    	        [DllImport("countbyone")]
            	private static extern int SomeMethod(int num);
    
    		public static void Main (string[] args)
    		{
    			var x = SomeMethod(0);
    			Console.WriteLine(x);
    		}
    	}
    }
