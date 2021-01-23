    using System;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			int number = 5;
			for (int i = 0; i < number; i++)
			{
				Console.Write(string.Concat(Enumerable.Repeat(" ", number - i))); // Left Spaces
				Console.Write("*"); // Left side
				if (i != 0) // If not first line 
				{
					Console.Write(string.Concat(Enumerable.Repeat(" ", i * 2 - 1))); // Middle Spaces
					Console.Write("*"); // Right side
				}
				Console.WriteLine();
			}
			
			for (int i = 0; i <= number; i++)
				Console.Write("* "); // Bottom
		}
	}
