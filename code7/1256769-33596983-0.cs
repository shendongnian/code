	public static IEnuemrable<T> DistinctConsecutive<T>(this IEnumerable<T> sequence)
		=> sequence.DistinctConsecutive(EqualityComaprer<T>.Default);
	public static IEnuemrable<T> DistinctConsecutive<T>(this IEnumerable<T> sequence, IEqualityComparer<T> comaprer)
	{
		if (comparer == null)
			throw new ArgumentNullException(nameof(comparer));
			
		using (var enumerator = sequence.GetEnumerator())
		{
			if (!enumerator.MoveNext())
				yield break;
				
			var lastValue = enumerator.Current;
			yield return lastValue;
			
			while (enumerator.MoveNext())
			{
				var value = enumerator.Current;
				if (comaprer.Equals(lastValue, value))
					continue;
					
				yield return value;
				lastValue = value;
			}
		}
	}
	
