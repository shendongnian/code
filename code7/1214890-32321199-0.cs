    using System;
    using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		private static Dictionary<int, int> _holeMap = new Dictionary<int, int>
		{
			{ 0, 1 },
			{ 1, 0 },
			{ 2, 0 },
			{ 3, 0 },
			{ 4, 1 },
			{ 5, 0 },
			{ 6, 1 },
			{ 7, 0 },
			{ 8, 2 },
			{ 9, 1 }				
		};
		
		public static void Main()
		{
			int numero = 12345678;
			int check = CountHoles(numero);
			Console.WriteLine(check);	
		}
		
		public static int CountHoles(int num){
			var digits = num
				.ToString()
				.Select(c => int.Parse(c.ToString()));
			
			return digits.Sum(d => _holeMap[d]);
		}
	}
