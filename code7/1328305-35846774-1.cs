    public List<DateTime> GetDatesBetween(DateTime start, DateTime end, params DayOfWeek[] weekdays)
	{
		bool allDays = weekdays == null || !weekdays.Any();
		
		var dates = Enumerable.Range(0, 1 + end.Subtract(start).Days)
							  .Select(offset => start.AddDays(offset))
							  .Where(d => allDays || weekdays.Contains(d.DayOfWeek))
							  .ToList();
		return dates;
	}
