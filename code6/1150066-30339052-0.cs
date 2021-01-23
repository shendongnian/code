    public static IEnumerable<double> FuzzyDistinct(this IEnumerable<double> source, double epsilon)
	{
		// If source is null yield an empty enumerable.
		if(source == null)
		{
			yield break;
		}
		
		// Get the source's enumerator.
		var enumerator = source.GetEnumerator();
		
		// If the source is empty yield an empty enumerator.
		if(!enumerator.MoveNext())
		{
			yield break;
		}
		
		// Get the current item and yield it.
		double current = enumerator.Current;
		yield return current;
		
		// Iterate over the remaining items, updating 'current' and yielding it
        // if it does not fall within the epsilon of the previous value.
		while(enumerator.MoveNext())
		{
			if(Math.Abs(enumerator.Current - current) > epsilon)
			{
				current = enumerator.Current;
				yield return current;
			}
		}
	}
