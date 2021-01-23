	namespace ConsoleApplication5
	{
		using System;
		class Program
		{
			static void Main(string[] args)
			{
				Console.WriteLine("This should be blank on first run, but not on subsequent: {0}", Properties.Settings.Default.test1);
				
				string value = "test";
				Properties.Settings.Default.test1 = value;
				Properties.Settings.Default.Save();
			}
		}
	}
