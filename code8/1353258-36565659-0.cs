	var startDate = new DateTime(2016,04,11);
	var endDate = new DateTime(2016,04,17);
	
	var ids = workers
		.Where(w => w.WorkDate >= startDate)
		.Where(w => w.WorkDate <= endDate)
		.GroupBy(w => w.Id)
		.Where(g => !g.Any(w => w.IsOff))
		.Select(g => g.Key);
