    static class Combinations
    {
        private static void SetIndexes(int[] indexes, int lastIndex, int count)
        {
            indexes[lastIndex]++;
            if (lastIndex > 0 && indexes[lastIndex] == count)
            {
                SetIndexes(indexes, lastIndex - 1, count - 1);
                indexes[lastIndex] = indexes[lastIndex - 1] + 1;
            }
        }
        private static bool AllPlacesChecked(int[] indexes, int places)
        {
            for (int i = indexes.Length - 1; i >= 0; i--)
            {
                if (indexes[i] != places)
                    return false;
                places--;
            }
            return true;
        }
	public static IEnumerable<IEnumerable<T>> GetDifferentCombinations<T>(this IEnumerable<T> c, int count)
	{
		var collection = c.ToList();
		int listCount = collection.Count();
		if (count > listCount)
			throw new InvalidOperationException($"{nameof(count)} is greater than the collection elements.");
		int[] indexes = Enumerable.Range(0, count).ToArray();
		do
		{
			yield return indexes.Select(i => collection[i]).ToList();
			SetIndexes(indexes, indexes.Length - 1, listCount);
		}
		while (!AllPlacesChecked(indexes, listCount));
	}
    }
