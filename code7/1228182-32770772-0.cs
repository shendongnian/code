            [Test, TestCaseSource("LocalSource")]
        public void SO_GetRemainingWorkingTimeWithHolidayShouldOnlyEnumerateWorkingTime(DateTime startTime,
            TimeSpan workingHours, DateTime expectedDueDate, string expectation)
        {
            CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
            filter.Months.Add(YearMonth.September); // only Januaries
            filter.WeekDays.Add(DayOfWeek.Monday); // 
            filter.WeekDays.Add(DayOfWeek.Tuesday); // 
            filter.WeekDays.Add(DayOfWeek.Wednesday); // 
            filter.WeekDays.Add(DayOfWeek.Thursday); // 
            filter.WeekDays.Add(DayOfWeek.Friday); // 
            filter.CollectingHours.Add(new HourRange(9, 17)); // working hours
            CalendarTimeRange testPeriod = new CalendarTimeRange(startTime, expectedDueDate);//new DateTime(2015, 9, 14, 9, 0, 0), new DateTime(2015, 9, 17, 18, 0, 0));
            Console.WriteLine("Calendar period collector of period: " + testPeriod);
            filter.ExcludePeriods.Add(new TimeBlock(new DateTime(2015, 9, 15, 00, 0, 0), new DateTime(2015, 9, 16, 0, 0, 0)));
            CalendarPeriodCollector collector = new CalendarPeriodCollector(filter, testPeriod);
            collector.CollectHours();
            foreach (ITimePeriod period in collector.Periods)
            {
                Console.WriteLine("Period: " + period); // THIS WILL HELP A LOT!
            }
            var result = collector.Periods.GetTotalDuration(new TimeZoneDurationProvider(TimeZoneInfo.FindSystemTimeZoneById("UTC")));
            Console.WriteLine(result);
                //
        }
