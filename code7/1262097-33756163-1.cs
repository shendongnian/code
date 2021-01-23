		public static class WeekOfYearProvider
		{
			private static CultureInfo CultureInfo { get; }
			private static Calendar Calendar { get; }
		
			static WeekOfYearProvider()
			{
				CultureInfo = CultureInfo.GetCultureInfo("en-US");
				Calendar = _cultureInfo.Calendar;
			}
		
			public static int GetWeekOfYear(DateTime dateTime)
			{
				return Calendar.GetWeekOfYear(dateTime,
					CultureInfo.DateTimeFormat.CalendarWeekRule,
					CultureInfo.DateTimeFormat.FirstDayOfWeek);
			}
		}    
