	var result =
		data
			.GroupBy(x => x.ID)
			.Select(xs => new
			{
				ID = xs.Key,
				Lessions = xs
					.Where(x => x.Lession.Intersect("EFGHI").Any())
					.ToArray(),
			})
			.Select(x => new
			{
				x.ID,
				Time = x.Lessions.Sum(y => y.Time),
				Score = x.Lessions.Sum(y => y.Score),
			})
			.ToArray();
