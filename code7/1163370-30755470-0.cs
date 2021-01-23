	void Main()
	{
		GetValues(new ResultA
		{
			Date = DateTime.Now,
			Year = 2000
		}).Dump();
	}
	
	public IDictionary<string, string> GetValues(object obj) 
	{
		return obj
				.GetType()
				.GetProperties()
				.ToDictionary(p=>p.Name, p=> p.GetValue(obj).ToString());
	}
	
	public class ResultA
	{
		public DateTime Date { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
	}
	
