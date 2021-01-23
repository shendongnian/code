		public static class WeekOfYearProvider
		{
			private static readonly CultureInfo _cultureInfo;
			private static readonly Calendar _calendar;
		
			static WeekOfYearProvider()
			{
				_cultureInfo = CultureInfo.GetCultureInfo("en-US");
				_calendar = _cultureInfo.Calendar;
			}
		
			public static int GetWeekOfYear(DateTime dateTime)
			{
				return _calendar.GetWeekOfYear(dateTime,
					_cultureInfo.DateTimeFormat.CalendarWeekRule,
					_cultureInfo.DateTimeFormat.FirstDayOfWeek);
			}
		}    
