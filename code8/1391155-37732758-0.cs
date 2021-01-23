    public static class Algorithms
    {
    	public static IEnumerable<T> MergeOrdered<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2, IComparer<T> comparer = null)		
    	{
    		if (comparer == null) comparer = Comparer<T>.Default;
    		using (var e1 = seq1.GetEnumerator())
    		using (var e2 = seq2.GetEnumerator())
    		{
    			bool more1 = e1.MoveNext(), more2 = e2.MoveNext();
    			while (more1 && more2)
    			{
    				int compare = comparer.Compare(e1.Current, e2.Current);
    				yield return compare < 0 ? e1.Current : e2.Current;
    				if (compare <= 0) more1 = e1.MoveNext();
    				if (compare >= 0) more2 = e2.MoveNext();
    			}
    			for (; more1; more1 = e1.MoveNext())
    				yield return e1.Current;
    			for (; more2; more2 = e2.MoveNext())
    				yield return e2.Current;
    		}
    	}
    }
