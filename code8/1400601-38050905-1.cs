    public static void Test1()
		{
			var systemTimeZone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault();
			//TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			var icalTimeZone = iCalTimeZone.FromSystemTimeZone(systemTimeZone);
			
			var startTimeSearch = new DateTime(2015, 9, 8, 0, 0, 0, DateTimeKind.Utc);
			var endTimeSearch = new DateTime(2015, 12, 1, 00, 0, 0, DateTimeKind.Utc);
			var iCalendar = new iCalendar();
			var pacificTimeZone = iCalendar.AddTimeZone(icalTimeZone);
			var _event =
			new Event
			{
				Summary = "This is an event at 2015-09-08 10:30 PST (2015-09-08 17:30 UTC)",
				DTStart = new iCalDateTime(2015, 9, 8, 10, 30, 0, pacificTimeZone.TZID, iCalendar),
				Duration = new TimeSpan(0, 1, 0, 0)
			};
			var rp = new RecurrencePattern("FREQ=WEEKLY;UNTIL=20151112T080000Z;WKST=SU;BYDAY=TU");
			_event.RecurrenceRules.Add(rp);
			iCalendar.Events.Add(_event);
			
			var occurrences = iCalendar.GetOccurrences(startTimeSearch, endTimeSearch);
		}
