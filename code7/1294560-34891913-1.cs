	var parents =
		elements
			.Where(x => x.ParentId != null)
			.ToDictionary(x => x.Id, x => x.ParentId.Value);
	
	Func<int, IEnumerable<int>> getParents = null;
	getParents = i =>
		parents.ContainsKey(i)
			? new [] { parents[i] }.Concat(getParents(parents[i]))
			: Enumerable.Empty<int>();
