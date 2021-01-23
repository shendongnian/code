	private static void MultipleEnumerations(IEnumerable<int> nums)
	{
		var otherNums = new List<int> { 1, 2, 3, 4, 5 };
		var filtered = otherNums.Where(num =>
		{
			Console.WriteLine("{0}?", num);
			return nums.Contains(num);
		});
		foreach (var num in filtered)
		{
			Console.WriteLine(num);
		}
	}
	
	private static IEnumerable<int> GetNums()
	{
		Console.WriteLine("4!");
		yield return 4;
		Console.WriteLine("2!");
		yield return 2;
	}
