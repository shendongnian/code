	public static IEnumerable<T> DistinctConsecutive<T>(this IEnumerable<T> sequence)
		=> sequence.DistinctConsecutive(EqualityComparer<T>.Default);
	public static IEnumerable<T> DistinctConsecutive<T>(this IEnumerable<T> sequence, IEqualityComparer<T> comparer)
	{
		if (sequence == null)
			throw new ArgumentNullException(nameof(sequence));
		if (comparer == null)
			throw new ArgumentNullException(nameof(comparer));
			
		return DistinctConsecutiveImpl(sequence, comparer);
	}
			
	private static IEnumerable<T> DistinctConsecutiveImpl<T>(IEnumerable<T> sequence, IEqualityComparer<T> comparer)
	{
		using (var enumerator = sequence.GetEnumerator())
		{
			if (!enumerator.MoveNext())
				yield break;
				
			var lastValue = enumerator.Current;
			yield return lastValue;
			
			while (enumerator.MoveNext())
			{
				var value = enumerator.Current;
				if (comparer.Equals(lastValue, value))
					continue;
					
				yield return value;
				lastValue = value;
			}
		}
	}
	
