	bool IsSubsequence<T>(IEnumerable<T> subseq, IEnumerable<T> superseq)
	    where T : IEquatable<T>
	{
	    var subit = subseq.GetEnumerator();
	    if (!subit.MoveNext()) return true; // Empty subseq -> true
	    foreach (var superitem in superseq)
	    {
	        if (superitem.Equals(subit.Current))
	        {
	            if (!subit.MoveNext()) return true;
	        }
	    }
	    return false;
	}
	
	List<List<T>> PruneSequences<T>(List<List<T>> lists)
	    where T : IEquatable<T>
	{
	    return lists
	        .Where(sublist =>
	            !lists.Any(superlist =>
	                sublist != superlist &&
	                IsSubsequence(sublist, superlist)))
	        .ToList();
	}
