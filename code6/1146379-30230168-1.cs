	int year = 2015;
	// Make list of periods ready
	List<Period> periodList = new List<Period>
	{
		new Period
		{
			StartDate = null,
			EndDate = new DateTime(year, 12, 1),
		},
		new Period
		{
			StartDate = new DateTime(year, 12, 2),
			EndDate = null,
		},
		new Period
		{
			StartDate = null,
			EndDate = new DateTime(year, 12, 4),
		},
		new Period
		{
			StartDate = new DateTime(year, 12, 6),
			EndDate = new DateTime(year, 12, 8),
		},
		new Period
		{
			StartDate = new DateTime(year, 12, 9),
			EndDate = null,
		},
		new Period
		{
			StartDate = null,
			EndDate = new DateTime(year, 12, 10),
		},
		new Period
		{
			StartDate = new DateTime(year, 12, 11),
			EndDate = null,
		}
	};
	
	
