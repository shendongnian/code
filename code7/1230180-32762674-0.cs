	void Main()
	{
		
		var data = new [] { 
			new Record(31, DateTime.Parse("2016-02-01")),
			new Record(31, DateTime.Parse("2016-02-03")),
			new Record(31, DateTime.Parse("2016-02-05")),
			new Record(31, DateTime.Parse("2016-02-08")),
			new Record(31, DateTime.Parse("2016-02-10")),
			new Record(31, DateTime.Parse("2016-02-12")),
			new Record(31, DateTime.Parse("2016-02-15")),
			new Record(31, DateTime.Parse("2016-02-16")),
			new Record(31, DateTime.Parse("2016-02-17")),
			new Record(31, DateTime.Parse("2016-02-22")),
			new Record(31, DateTime.Parse("2016-02-24")),
			new Record(31, DateTime.Parse("2016-02-26")),
			new Record(31, DateTime.Parse("2016-02-29")),
			new Record(31, DateTime.Parse("2016-03-02")),
			new Record(31, DateTime.Parse("2016-03-04")),
			new Record(31, DateTime.Parse("2016-03-07")),
			new Record(31, DateTime.Parse("2016-03-09")),
			new Record(31, DateTime.Parse("2016-03-11"))
		};
		
		(
			from rec in data
			group rec by new { ID = rec.Id,  WeekNum = new GregorianCalendar().GetWeekOfYear(rec.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday)} into g
			select new { 
				ID = g.Key.ID, 
				FromDate = g.First().Date, 
				LastDate = g.Last().Date,
				OPERATINGDAY_MONDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Monday) != null),
				OPERATINGDAY_TUESDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Tuesday) != null),
				OPERATINGDAY_WEDNESDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Wednesday) != null),
				OPERATINGDAY_THURSDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Thursday) != null),
				OPERATINGDAY_FRIDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Friday) != null),
				OPERATINGDAY_SATURDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Saturday) != null),
				OPERATINGDAY_SUNDAY = (g.FirstOrDefault(x=>x.Date.DayOfWeek == DayOfWeek.Sunday) != null),
			}
		).Dump();
	}
	
	// Define other methods and classes here
	class Record
	{
		public int Id {get;set;}
		public DateTime Date {get;set;}
		public string Day {get;set;}
		
		public Record (int id, DateTime date)
		{
			Id = id;
			Date = date;
		}
	}
