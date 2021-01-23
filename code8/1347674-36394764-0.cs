	Func<IEnumerable<MyClass>, IEnumerable<IEnumerable<MyClass>>> getAllSubsets = null;
	getAllSubsets = xs =>
		(xs == null || !xs.Any())
			? Enumerable.Empty<IEnumerable<MyClass>>()
			:  xs.Skip(1).Any()
				? getAllSubsets(xs.Skip(1))
					.SelectMany(ys => new [] { ys, xs.Take(1).Concat(ys) })
				: new [] { Enumerable.Empty<MyClass>(), xs.Take(1) };
	Random rnd = new Random();				
	MyClass[] array = Enumerable.Range(0, 10).Select(x => new MyClass() { cost = rnd.Next(5, 100) }).ToArray();
	var result =
		getAllSubsets(array)
			.Select(x => new
			{
				MyClass = x,
				TotalCost = x.Sum(y => y.cost),
			})
			.Where(x => x.TotalCost <= 50)
			.OrderByDescending(x => x.TotalCost)
			.FirstOrDefault();
