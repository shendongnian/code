	namespace SortListTest1
	{
		using System;
		using System.Collections.Generic;
		using System.Linq;
		class Program
		{
			static void Main(string[] args)
			{
				var animals = new List<string> { "10 dog", "53 cow", "2 crow", "29 horse", "12 rabbit", "107 frog", "35 cat", "7 dragon" };
				var orderedAnimals = animals.OrderBy(
					x =>
						{
							var parts = x.Split(' '); // split on first space
							return int.Parse(parts[0]); // i.e. the numeric part, cast to an int
						});
				foreach (var orderedAnimal in orderedAnimals)
				{
					Console.WriteLine(orderedAnimal);
				}
			}
		}
	}
----------
	2 crow
	7 dragon
	10 dog
	12 rabbit
	29 horse
	35 cat
	53 cow
	107 frog
	Press any key to continue . . .
