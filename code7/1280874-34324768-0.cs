	private static IEnumerable<IEnumerable<T>> GetCombinations<T>(IList<T> list, int length)
	{
		var numberOfCombinations = (long)Math.Pow(list.Count, length);
		for(long i = 0; i < numberOfCombinations; i++)
		{
			yield return BuildCombination(list, length, i);
		}
	}
	private static IEnumerable<T> BuildCombination<T>(
		IList<T> list, 
		int length, 
		long combinationNumber)
	{
		var temp = combinationNumber;
		for(int j = 0; j < length; j++)
		{
			yield return list[(int)(temp % list.Count)];
			temp /= list.Count;
		}
	}
