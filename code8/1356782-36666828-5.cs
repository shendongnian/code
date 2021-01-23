	void Main()
	{
		int period = 1;
		DateTime start = new DateTime(2016, 3, 1);
		var result = Enumerable.Range(0, 12)
			.Select((i, m) => new { index = i, Month = start.AddMonths(m).ToString("MMMM-yyyy")})
			.GroupBy(o => (o.index) / period);
		
		foreach (var grp in result)
		{
			if (grp.Count() == 1)
			{
				Console.WriteLine(grp.First().Month);
			}
			else
			{
				Console.WriteLine(string.Format("{0} - {1}", grp.First().Month, grp.Last().Month));
			}
			Console.WriteLine("****");
		}
	}
