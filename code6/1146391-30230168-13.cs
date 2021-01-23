	// Clear list of periods
	periodList.Clear();
	// Add start dates which are bigger than LAST end date with NULL end date period
	startDates.Where(s => s > endDates.Max())
		.ToList()
		.ForEach(s => periodList.Add(new Period() { StartDate = s, EndDate = null }));
	// Add end dates which are smaller than FIRST start date with NULL start date period
	endDates.Where(e => e < startDates.Min())
		.ToList()
		.ForEach(e => periodList.Add(new Period() {StartDate = null, EndDate = e}));
	// Match other dates and add them to list
	startDates.Where(s => s < endDates.Max())
		.ToList()
		.ForEach(s => periodList.Add(new Period()
									{
										StartDate = s,
										EndDate = endDates.Where(e => e > s).Min()
									}));
	// Oder period list
	periodList = periodList.OrderBy(p => p.StartDate).ToList();
