    using System;
    using System.Text;
    
    namespace stringy
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string hello = "Hello World!";
    			int i = 123;
    			double d = 3.14;
    			StringBuilder sb = new StringBuilder();
    			sb.Append(hello);
    			sb.Append(i);
    			sb.Append(d);
    			Console.WriteLine (sb.ToString());
    		}
    	}
    }
