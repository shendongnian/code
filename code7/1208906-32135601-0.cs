	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApplication2
	{
		class Program
		{
			static void Main(string[] args)
			{
				var name = "   name  ";
				var nameParts = name.Trim().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
				if (nameParts.Length < 2)
				{
					Console.WriteLine("You've only entered one name");
				}
				else
				{
					Console.WriteLine("First part: {0}", nameParts[0]);
					Console.WriteLine("Second part: {0}", nameParts[1]);
				}
			}
		}
	}
