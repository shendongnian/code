    public static IEnumerable<IEnumerable<T>> AscendingSubsets<T>(this IEnumerable<T> superset) where T :IComparable<T>
	{     
		var supersetEnumerator = superset.GetEnumerator();
		if (!supersetEnumerator.MoveNext())
		{
			yield break;
		}    
		T oldItem = supersetEnumerator.Current;
		List<T> subset = new List<T>() { oldItem };
		while (supersetEnumerator.MoveNext())
		{
			T currentItem = supersetEnumerator.Current;
			if (currentItem.CompareTo(oldItem) > 0)
			{
				subset.Add(currentItem);
			}
			else
			{
				yield return subset;
				subset = new List<T>() { currentItem };
			}
			oldItem = supersetEnumerator.Current;
		}
		yield return subset;
	}
