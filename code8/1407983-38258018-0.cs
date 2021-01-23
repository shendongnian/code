	Dictionary<string, int[]> QandA_Dictionary = new Dictionary<string, int[]>();
	QandA_Dictionary.Add("What is 1 + 1?", new int[] { 1, 2, 3, 4 });
	QandA_Dictionary.Add("What is 1 + 2?", new int[] { 1, 2, 3, 4 });
	QandA_Dictionary.Add("What is 1 + 3?", new int[] { 1, 2, 3, 4 });
	QandA_Dictionary.Add("What is 1 + 4?", new int[] { 2, 3, 4, 5 });
	foreach (var pair in QandA_Dictionary)
	{
		Console.WriteLine("{0},{1}", pair.Key, String.Join(", ", pair.Value));
	}
	Console.ReadKey();
