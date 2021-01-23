	void Main()
	{
		
		ReportType tp = ReportType.Monthly;
		DateTime start = new DateTime(2016,3,1);
		List<DateTime> months = Enumerable.Range(0, 12).Select(m => start.AddMonths(m)).ToList();
		
		var result = months.Where((m, i) => i % (int)tp == 0).Select(m => m.ToString("MMMM"));
		
		foreach (var r in result)
		{
			Console.WriteLine(r);
		}
		
	}
	public enum ReportType
	{
		Yearly = 12,
		SemiAnnually = 6,
		Quarterly = 3,
		Monthly = 1
	}
