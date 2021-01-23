	var query =
		from ci in customItems
		group ci by new { ci.TargetDate, ci.Name } into gcis
		select new Custom()
		{
			TargetDate = gcis.Key.TargetDate,
			Name = gcis.Key.Name,
			Price = gcis.Sum(x => x.Price),
			Value = gcis.Average(x => x.Value),
		};
	
	List<Custom> results = query.ToList();
