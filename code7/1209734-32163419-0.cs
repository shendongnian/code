	using System;
	using System.IO;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var list = File.ReadLines("C:\\MusicExaminer\\frequencies.txt")
				.Select(line => double.Parse(line))
				.ToList();
            for (item in list)
            {
                Console.WriteLine(item.ToString());
            }
		}
	}
