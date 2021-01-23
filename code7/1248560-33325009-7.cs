	  public static IQueryable<int> MaxIndices(this IQueryable<int> source)
	  {
		if (source is EnumerableQuery<int>)
		  return MaxIndices((IEnumerable<int>)source).AsQueryable(); // most efficient approach with enumerables.
		return source.Select((n, i) => new { n, i })
		  .GroupBy(x => x.n, x => x.i)
		  .OrderByDescending(x => x.Key)
		  .FirstOrDefault() ?? Enumerable.Empty<int>().AsQueryable();
	  }
