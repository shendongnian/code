	Func<IEnumerable<int>, IEnumerable<int[]>> permutate = null;
	permutate = ns =>
	{
		if (!ns.Skip(1).Any())
		{
			return new [] { ns.ToArray() };
		}
		else
		{
			return
				from n in ns
				from ns2 in permutate(ns.Except(new [] { n }))
				select new [] { n }.Concat(ns2).ToArray();
		}
	};
	var results =
		permutate(Enumerable.Range(1, 9))
			.Where(ns => Enumerable.Range(0, 3).All(n => ns[n * 3] + ns[n * 3 + 1] + ns[n * 3 + 2] == 15))
			.Where(ns => Enumerable.Range(0, 3).All(n => ns[n] + ns[3 + n] + ns[6 + n] == 15))
			.Where(ns => Enumerable.Range(0, 3).All(n => ns[0] + ns[4] + ns[8] == 15))
			.Where(ns => Enumerable.Range(0, 3).All(n => ns[2] + ns[4] + ns[6] == 15));
