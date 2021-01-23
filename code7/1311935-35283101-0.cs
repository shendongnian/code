	List<Thing> x = new List<Thing>()
	{
		new Thing () { ID = 1, StartDate = new DateTime(2012, 1, 1), EndDate  = new DateTime(2014, 1, 1) },
		new Thing () { ID = 2, StartDate = new DateTime(2013, 1, 1), EndDate  = new DateTime(2015, 1, 1) },
		new Thing () { ID = 3, StartDate = new DateTime(2014, 1, 1), EndDate  = new DateTime(2016, 1, 1) },
		new Thing () { ID = 4, StartDate = null, EndDate  = new DateTime(2015, 1, 1) },
		new Thing () { ID = 5, StartDate = new DateTime(2016, 1, 1), EndDate  = new DateTime(2017, 1, 1) },
	};
	
	Func<Thing, Thing, bool> overlaps =
		(t0, t1) =>
			(t0.StartDate.HasValue ? t0.StartDate.Value <= t1.EndDate : false)
				&& (t1.StartDate.HasValue ? t0.EndDate >= t1.StartDate : false);
				
	var y = x.Skip(1).Aggregate(x.Take(1).ToList(), (a, b) =>
	{
		if (a.All(c => !overlaps(b, c)))
		{
			a.Add(b);
		}
		return a;
	});
