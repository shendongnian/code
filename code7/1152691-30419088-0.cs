        using System;
		using System.Collections.Generic;
		namespace AverageNumbers
		{
			class MainClass
			{
				public static void Main (string[] args)
				{
					List<int> numbers = new List<int>();
					int n, sum = 0;
					while (int.TryParse(Console.ReadLine(), out n))
					{
						sum += n;
						numbers.Add(n);
					}
					Console.WriteLine("Average: " + (numbers.Count > 0? sum / numbers.Count : 0));
				}
			}
		}
