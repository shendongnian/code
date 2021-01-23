	DateTime startDate = DateTime.Now;
	Random rnd = new Random();
	var oneYear = 60*60*24*365;
	
	List<DateTime> datesList =
		Enumerable
			.Range(0, oneYear)
			.Where(i => rnd.Next(1, 5) != 4)
			.Select(i => startDate.AddSeconds(i))
			.ToList();
			
	List<List<DateTime>> segregatedList =
		datesList
			.Skip(1)
			.Aggregate(
				datesList
					.Take(1)
					.Select(x => new List<DateTime>() { x })
					.ToList(),
					(a, x) =>
					{
						if (x.Subtract(a.Last().Last()) == TimeSpan.FromSeconds(1.0))
						{
							a.Last().Add(x);
						}
						else
						{
							a.Add(new List<DateTime>() { x });
						}
						return a;
					});
