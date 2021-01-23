        DateTime dt = new DateTime(2016,6,1); // 1st Day of the Month.
		var thirdWorkingDay = Enumerable.Range(0,7)
			.Select(x=> dt.AddDays(x))
			.FirstOrDefault(x=> x.DayOfWeek != DayOfWeek.Sunday && x.DayOfWeek != DayOfWeek.Saturday)
			.AddDays(2);
 
