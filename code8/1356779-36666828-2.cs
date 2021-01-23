	void Main()
	{
		int period = 6;
		DateTime start = new DateTime(2016, 3, 1);
		var result = Enumerable.Range(0, 13)
			.Select(m => start.AddMonths(m))
			.GroupBy(o => (o.Month - 1) / period);
		
		foreach (var grp in result)
		{
			if (period == 1)
			{
				Console.WriteLine(grp.First().ToString("MMMM"));
			}
			else
			{
				Console.WriteLine(string.Format("{0} - {1}", grp.First().ToString("MMMM"), grp.Last().ToString("MMMM")));
			}
		}
	}
