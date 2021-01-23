	var parents = elements.ToDictionary(x => x.Id, x => x.ParentId);
	
	Func<int, IEnumerable<int?>> getParents = null;
	getParents = i =>
		parents.ContainsKey(i)
			? new [] { parents[i] }.Concat(parents[i].HasValue
				? getParents(parents[i].Value)
				: Enumerable.Empty<int?>())
			: Enumerable.Empty<int?>();
