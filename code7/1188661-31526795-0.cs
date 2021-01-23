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
    			system(@"printf '\e[8;50;100t'");
    			Console.WriteLine ("We will be 50 lines and 100 columns in Terminal.app now");
    			Console.ReadKey ();
    		}
    	}
    }
