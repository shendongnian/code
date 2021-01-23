	const int StartYear = 2015;
	const int TotalYears = 3;
	var years = new System.Collections.Generic.List<object>();
	for (int id = 1, year = StartYear; id <= TotalYears; id++, year++)
	{
		years.Add(new { ID = Convert.ToString(id), Name = Convert.ToString(year) });
	}
	var list = new SelectList(years, "ID", "Name", 2);
