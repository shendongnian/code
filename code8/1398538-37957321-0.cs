	var dateList = new List<DateTime>
	{
		new DateTime(2012, 06, 01),
		new DateTime(2012, 06, 02),
		//..etc
	};
	
	var startDate = new DateTime(2012, 06, 01);
	var endDate = new DateTime(2012, 06, 15);
	var dateRange =
		Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
		.Select(i => startDate.AddDays(i));
	
    var datesNotMatched = dateRange.Except(dateList);
