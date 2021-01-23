    using System;
    
    namespace ConsoleParameter
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			// get from the command line parameter
    			Console.WriteLine("Parameter in command line");
    			foreach (var arg in args)
    			{
    				Console.WriteLine(arg);
    			}
    
    			// get from keyboard input when the console is running
    			Console.WriteLine("Please input something");
    			var value = Console.ReadLine();
    			Console.WriteLine("You entered {0}", value);
    
    			Console.ReadKey(true);
    		}
    	}
    }
