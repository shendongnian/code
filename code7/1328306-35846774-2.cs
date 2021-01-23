	public List<DateTime> GetDatesBetween(DateTime start, DateTime end)
	{
		var dates = Enumerable.Range(0, 1 + end.Subtract(start).Days)
							  .Select(offset => start.AddDays(offset))
							  .ToList();
		return dates;
	}
