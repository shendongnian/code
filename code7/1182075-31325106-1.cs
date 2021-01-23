	public static void Main()
	{
		List<string> permutations = new List<string>();
		GenerateHeapPermutations(3, new [] { 'A', 'B', 'C' }, permutations);
		foreach (var p in permutations)
		{
			Console.WriteLine(p);
		}
		Console.ReadKey();
	}
	public static void GenerateHeapPermutations(int n, char[] charArray, List<string> sList)
	{
		if (n == 1)
		{
			sList.Add(new string(charArray));
		}
		else
		{
			for (int i = 0; i < n - 1; i++)
			{
				GenerateHeapPermutations(n - 1, charArray, sList);
				int indexToSwapWithLast = (n%2 == 0 ? i : 0);
				// swap the positions of two characters
				var temp = charArray[indexToSwapWithLast];
				charArray[indexToSwapWithLast] = charArray[n - 1];
				charArray[n - 1] = temp;
			}
			GenerateHeapPermutations(n - 1, charArray, sList);
		}
	}
