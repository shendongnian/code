    var holidays = new List<Holiday>();
    // New Year's Day
    holidays.Add(new MonthDayBasedHoliday(1, 1));
    // President's Day (US)
    holidays.Add(new DayOfWeekBasedHoliday(3, DayOfWeek.Monday, 2));
    // Easter
    holidays.Add(new FixedDateBasedHoliday(new DateTime(2015, 4, 5), new DateTime(2016, 3, 27)));
    // Memorial Day (US)
    holidays.Add(new DayOfWeekBasedHoliday(5, DayOfWeek.Monday, 5));
    // Christmas
    holidays.Add(new MonthDayBasedHoliday(12, 25));
