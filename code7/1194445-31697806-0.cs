    public static IEnumerable<Counterpart> SearchWithRank(this IEnumerable<Counterpart> source, string pattern)
    {
		var sources = new []
		{
        	source.Where(x => x.Code == pattern),
			source.Where(x => x.Code.StartsWith(pattern)),
			source.Where(x => x.Code.Contains(pattern)),
			source.Where(x => x.Description.Contains(pattern)),
			source.Where(x => x.Aliases != null && x.Aliases.Any(y => y.Description == pattern)),
			source.Where(x => x.Aliases != null && x.Aliases.Any(y => y.Description.StartsWith(pattern))),
			source.Where(x => x.Aliases != null && x.Aliases.Any(y => y.Description.Contains(pattern))),
		};
        Stopwatch sw = Stopwatch.StartNew();
		
        var rankedItems =
			sources
				.SelectMany((x, n) => x.Select(y => new CounterPartRanking { Rank = n + 1, CounterPart = y }))
				.ToList();
		sw.Stop();
        Debug.WriteLine("Time elapsed {0} for {1}", sw.Elapsed, pattern);
        var items = rankedItems.OrderBy(x => x.Rank).Select(x => x.CounterPart);
        var distinct = items.Distinct();
        return distinct;
    }
