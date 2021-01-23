	Func<IEnumerable<int>, IEnumerable<IEnumerable<int>>> getAllSubsets = null;
	getAllSubsets = xs =>
		(xs == null || !xs.Any())
			? Enumerable.Empty<IEnumerable<int>>()
			:  xs.Skip(1).Any()
				? getAllSubsets(xs.Skip(1))
					.SelectMany(ys => new [] { ys, xs.Take(1).Concat(ys) })
				: new [] { Enumerable.Empty<int>(), xs.Take(1) };
