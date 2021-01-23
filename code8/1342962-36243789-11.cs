    using System;
	using System.Linq;
	using System.Collections.Generic;					
	
	public class Program
	{
		private static class WonkyCache
		{
			private static List<object> cache = new List<object>();
			
			public static void Add(object myItem)
			{
				cache.Add(myItem);
			}
			
			public static IEnumerable<T> Get<T>()
			{
				var result = cache.OfType<T>().ToList();
				return result;
			}
		}
	
		public static void Main()
		{
			WonkyCache.Add(1);
			WonkyCache.Add(2);
			WonkyCache.Add(3);
			WonkyCache.Add(Guid.NewGuid());
			WonkyCache.Add("George");
			WonkyCache.Add("Abraham");
			
			var numbers = WonkyCache.Get<int>();
			Console.WriteLine(numbers.GetType());			
			foreach(var number in numbers)
			{
				Console.WriteLine(number);
			}
			
			var strings = WonkyCache.Get<string>();
			Console.WriteLine(strings.GetType());
			
			foreach(var s in strings)
			{
				Console.WriteLine(s);
			}
		}
	}
	
