    	private static void foo()
		{
			SortedList<int, List<int>> collection = new SortedList<int, List<int>>();
			Random rnd = new Random();
			// Filling the collection with random keys/values:
			for (int i = 0; i < 100; i++)
			{
				int key = rnd.Next(0, 10);
				if (!collection.ContainsKey(key))
					collection.Add(key, new List<int>());
				for (int j = 0; j < 10; j++)
				{
					int value = rnd.Next(0, 1000);
					collection[key].Add(value);
				}
			}
			// Displaying all pairs:
			foreach (var key in collection.Keys)
			{
				collection[key].Sort();
				for (int j = 0; j < collection[key].Count; j++)
					Console.WriteLine(string.Format("[{0},{1}]", key, collection[key][j]));
			}
		}
