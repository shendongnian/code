	string[] names = new[] { "Foo", "Bar", "Fix" };
	// The weights will be 3, 2, 1
	int[] weights = new int[names.Length];
	for (int i = 0; i < names.Length; i++)
	{
		weights[i] = names.Length - i;
	}
	int[] cumulativeWeights = new int[names.Length];
	// The cumulativeWeights will be 3, 5, 6
	// so if we generate a number, 1-3 Foo, 4-5 Bar, 6 Fiz
	cumulativeWeights[0] = weights[0];
	int totalWeight = weights[0];
	for (int i = 1; i < cumulativeWeights.Length; i++)
	{
		cumulativeWeights[i] = cumulativeWeights[i - 1] + weights[i];
		totalWeight += weights[i];
	}
	var rnd = new Random();
	while (true)
	{
		int selectedWeight = rnd.Next(totalWeight) + 1; // random returns 0..5, +1 == 1..6
		int ix = Array.BinarySearch(cumulativeWeights, selectedWeight);
		// If value is not found and value is less than one or more 
		// elements in array, a negative number which is the bitwise 
		// complement of the index of the first element that is 
		// larger than value.
		if (ix < 0)
		{
			ix = ~ix;
		}
		Console.WriteLine(names[ix]);
	}
