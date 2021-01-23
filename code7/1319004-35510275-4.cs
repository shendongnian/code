    using static Utility;
    
    static class Utility {
    	public static void print(string format, params object[] parms) {
    		System.Console.WriteLine (format, parms);
    	}
    }
    
    namespace TestConsole
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			print ("Test {0}", "this");
    		}
    	}
    }
