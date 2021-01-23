    static class Combinations2
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
    
    	private static IEnumerable<T> TakeAt<T>(int[] indexes, IEnumerable<T> list)
    	{
    		for (int i = 0; i < indexes.Length; i++)
    		{
    			yield return list.ElementAt(indexes[i]);
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
    
    	public static IEnumerable<IEnumerable<T>> GetDifferentCombinations<T>
              (this IEnumerable<T> collection, int count)
    	{
    		int listCount = collection.Count();
    		if (count > listCount)
    			throw new InvalidOperationException(
                            $"{nameof(count)} is greater than the collection elements.");
    		int [] indexes = Enumerable.Range(0, count).ToArray();
    		do
    		{
    			var selected = TakeAt(indexes, collection);
    			yield return selected;
    			SetIndexes(indexes, indexes.Length - 1, listCount);
    		}
    		while (!AllPlacesChecked(indexes, listCount));
    	}
    }
