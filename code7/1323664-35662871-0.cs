	using System;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			var numbers = new int[2] {0,1};
			
			var result = numbers.Select(i => i + 3);
			
			foreach (var value in result)
			{
				Console.WriteLine(value);
			}		
		}
	}
