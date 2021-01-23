    using System;
    
    namespace Example
    {
    	internal class Program
    	{
    		public static void Main(string[] args)
    		{
    			var @int = Foo<int>("3");
    			var @double = Foo<double>("3.14");
    			var dateTime = Foo<DateTime>("01/02/2016");
    			var @decimal = Foo<decimal>("3.1");
    
    			Console.WriteLine($"{@int} is a {@int.GetType()}");
    			Console.WriteLine($"{@double} is a {@double.GetType()}");
    			Console.WriteLine($"{dateTime} is a {dateTime.GetType()}");
    			Console.WriteLine($"{@decimal} is a {@decimal.GetType()}");
    
    			Console.ReadLine();
    		}
    
    		public static T? Foo<T>(string val) where T : struct, IConvertible
    		{
    			return string.IsNullOrEmpty(val) ? null : Convert.ChangeType(val, typeof(T)) as T?;
    		}
    	}
    }
