	public static IEnumerable<T> DistinctConsecutive<T>(this IEnumerable<T> sequence, IEqualityComparer<T> comparer = null)
	{
		if (comparer == null)
			comparer = EqualityComparer<T>.Default;
			
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
	
