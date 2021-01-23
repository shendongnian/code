	var doubles =
		text
			.Skip(1)
			.Aggregate(
				text.Take(1).Select(x => x.ToString()).ToList(),
				(a, c) =>
				{
					if (a.Last().Last() == c)
						a[a.Count - 1] += c.ToString();
					else
						a.Add(c.ToString());
					return a;
				})
			.Select(x => x.Length / 2)
			.Sum();
