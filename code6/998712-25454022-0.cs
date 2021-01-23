	var sdt = CombineParameters(startDate, startTime);
	var edt = CombineParameters(endDate, endTime);
	var model = db.Results(startDate, endDate)
				.Where(r => (CombineParameters(r.A_Date, r.A_Time) >= sdt))
				.Where(r => (CombineParameters(r.A_Date, r.A_Time) <= edt))
				.OrderBy(r => r.A_Time)
				.OrderBy(r => r.A_Date)
				.Take(1000)
	);
	// Date and Time classes below are only examples, they do not exist
	// Prolly you are using string ;)
	private DateTime CombineParameters(Date dt, Time tt)
	{
		// some way to combine dt and tt to DateTime
		// you might have to do NULL checks here etc.
	}
