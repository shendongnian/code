	private static void Main(string[] args)
	{
		var target = 12;
		var listOfLists = new List<List<decimal>>()
		{
			new List<decimal> { 1, 2, 3 },
			new List<decimal> { 3, 4, 5 },
			new List<decimal> { 5, 6, 7 },
		};
		foreach (var combination in FindCombinations(listOfLists, target))
		{
			Console.WriteLine("{0} = {1}", string.Join(" + ", combination.Select(y => y.ToString(CultureInfo.InvariantCulture))), target);
		}
		Console.ReadKey();
	}
