	using System;
	namespace MyProgram
	{
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					throw new Exception("OH NO");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.StackTrace);
				}
				Console.ReadLine();
			}
		}
	}
