		public DateTime? FifthDay(DayOfWeek dayOfWeek, byte monthNum, int year)
		{
			if (monthNum > 12 || monthNum < 1)
			{
				throw new Exception("Month value should be between 1 and 12");
			}
			var searchDate = new DateTime(year, monthNum, 1);
			var weekDay = searchDate.DayOfWeek;
			if (weekDay == dayOfWeek)
			{
				searchDate = searchDate.AddDays(28);
			}
			for (DateTime d = searchDate; d < d.AddDays(7); d = d.AddDays(1))
			{
				if (d.DayOfWeek == dayOfWeek)
				{
					searchDate = searchDate.AddDays(28);
					break;
				}
			}
			if (searchDate.Month == monthNum)
				return searchDate;
			return null;
		}
