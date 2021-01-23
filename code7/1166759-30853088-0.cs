	namespace ConsoleApplication1
	{
		using System;
		internal class Program
		{       
			private static void Main(string[] args)
			{
				var arbitraryDate = DateTime.Today;
				do
				{
					arbitraryDate = arbitraryDate.AddDays(1);
				}
				while (arbitraryDate.DayOfWeek != DayOfWeek.Monday);
				Console.WriteLine(arbitraryDate.ToString("MM.dd.yyyy"));
			}
		}
	}
