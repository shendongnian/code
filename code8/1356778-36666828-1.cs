	void Main()
	{
		ReportType tp = ReportType.Yearly;
		DateTime start = new DateTime(2016,3,1);
		List<DateTime> months = Enumerable.Range(0, 13).Select(m => start.AddMonths(m)).ToList();
		var result = months.GetNth(tp).Select(m => m.ToString("MMMM"));
		
		foreach (var r in result)
		{
			Console.WriteLine(r);
		}
		
	}
	public static class MyListExtensions
	{
		public static IEnumerable<T> GetNth<T>(this List<T> list, ReportType tp)
		{
			List<int> skips = null;
			switch(tp)
	        {
				case ReportType.Monthly:
					skips = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11};
					break;
				case ReportType.Quarterly:
					skips = new List<int> {0,2,3,5,6,8,9,11};
					break;
				case ReportType.SemiAnnually:
					skips = new List<int> { 0,6,7,11 };
					break;
				case ReportType.Yearly:
					skips = new List<int> { 0, 11 };
					break;
			}
			foreach (int i in skips)
				yield return list[i];
	    }
	}
	public enum ReportType
	{
		Yearly = 12,
		SemiAnnually = 6,
		Quarterly = 3,
		Monthly = 1
	}
