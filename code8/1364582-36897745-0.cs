	=> dc.Patient
		.Include("first")
		.Select(a => new
		{
			Patient = a,
			Date = a.Assess.Max(x => x.Date),
			M3 = a.M3,
			Assess = a.Assess,
			Details = a.Assess.Select(x => new
			{
				x.Key,
				x.Team
			})
		})
		.Where(a => a.Date >= startdate && a.Date < stopdate && a.Assess.Any(ass => ass.column1 == 10))
		.OrderBy(a => a.Date)
		.Take(batchSize)
		.ToList()
	);
	
