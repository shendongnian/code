	Dictionary<int, Dictionary<int, string>> query =
	(
		from a in activities
		join p in projects on a.ProjectId equals p.ProjectId
		group new
		{
			a.Date.Month,
			p.ProjectNumber,
		} by a.Date.Year into gaps
		select new
		{
			gaps.Key,
			Value = gaps.ToDictionary(x => x.Month, x => x.ProjectNumber),
		}
	).ToDictionary(x => x.Key, x => x.Value);
