    using (Repository r = new Repository(@"[repo_location]"))
	{
		CommitFilter cf = new CommitFilter
		{
			SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
			ExcludeReachableFrom = r.Branches["master"].Tip,
			IncludeReachableFrom = r.Head.Tip
		};
		
		var results = r.Commits.QueryBy(cf);
		foreach (var result in results)
		{
			//Process commits here.
		}
	}
