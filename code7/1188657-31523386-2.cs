    using System;
    using System.Runtime.InteropServices;
    
    namespace Demo.Native.ResizeTerm
    {
    	class MainClass
    	{
    		[DllImport ("libc")]
    		private static extern int system (string exec);
    
    
    		public static void Main (string[] args)
    		{
    			system("resize -s 50 100 > /dev/null");
    			Console.WriteLine ("We will be 50 lines and 100 columns in Terminal.app now");
    			Console.ReadKey ();
    		}
    	}
    }
