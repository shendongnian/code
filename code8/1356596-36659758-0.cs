    using System;
    using Newtonsoft.Json.Linq;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main()
    		{
    			string input = "Hello, world!";
    			JToken token = JToken.FromObject(input);
    			object output = token.ToObject<object>();
    			Console.WriteLine(output);
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
    		}
    	}
    }
