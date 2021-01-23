	using System;
	using System.Collections.Generic;
	using System.IO;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					var list = new List<double>();
					using (var file = new StreamReader("C:\\MusicExaminer\\frequencies.txt"))
					{
						var line = string.Empty;
						while ((line = file.ReadLine()) != null)
						{
							list.Add(double.Parse(line));
						}
					}
					Notes(list);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
				Console.ReadKey();
			}
			static void Notes(List<double> list)
			{
				foreach (var s in list)
				{
					Console.WriteLine(s);
				}
			}
		}
	}
