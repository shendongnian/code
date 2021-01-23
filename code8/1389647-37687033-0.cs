    using System;
    
    namespace Example
    {
    	internal class Program
    	{
    		public static void Main(string[] args)
    		{
    			var @int = Foo<int>("3");
    			var @double = Foo<double>("3");
    
    			Console.WriteLine($"{@int} is a {@int.GetType()}");
    			Console.WriteLine($"{@double} is a {@double.GetType()}");
    			
    			Console.ReadLine();
    		}
    
    		public static T? Foo<T>(string val) where T : struct
    		{
    			return string.IsNullOrEmpty(val) ? (T?) null : Convert.ChangeType(val, typeof(T)) as T?;
    		}
    	}
    }
