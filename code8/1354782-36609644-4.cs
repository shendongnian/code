    using System;
    
    namespace ConsoleApplication
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			F();
    		}
    
    		public static void F()
    		{
    			var rnd1 = new Random();
    			var rnd2 = new Random();
    			Action a1 = () => G(rnd1);
    			Action a2 = () => G(rnd2);
    		}
    
    		private static void G(Random r)
    		{
    		}
    	}
    }
