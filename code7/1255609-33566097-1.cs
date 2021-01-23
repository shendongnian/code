	public static class Utils
	{
        // ...
		public static void RandomShuffle<T>(this T[,] target, Random random = null)
		{
			if (target.Length < 2) return;
			if (random == null) random = new Random();
			int columnCount = target.GetLength(1);
			for (int i = target.Length - 1; i > 0; i--)
			{
				int j = random.Next(i + 1);
				if (i != j) Swap(ref target[i / columnCount, i % columnCount], ref target[j / columnCount, j % columnCount]);
			}
		}
	}
