	var input = new[] { 1, 2, 3, 5, 8, 9, 10 };
	var result =
		input
			.Skip(1)
			.Aggregate(
				input.Take(1).Select(x => new { start = x, end = x }).ToList(),
				(a, x) =>
				{
					var last = a.Last();
					if (last.end + 1 == x)
					{
						a[a.Count - 1] = new { start = last.start, end = x };
					}
					else
					{
						a.Add(new { start = x, end = x });
					}
					return a;
				});
