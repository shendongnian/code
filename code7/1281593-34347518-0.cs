    // Exclude all dates before the start of this year
    MyDatePicker.BlackoutDates.Add(
       new CalendarDateRange(DateTime.MinValue, new DateTime(DateTime.Now.Year - 1, 12, 31)));
    // Exclude all dates after the end of this year
    MyDatePicker.BlackoutDates.Add(
       new CalendarDateRange(new DateTime(DateTime.Now.Year + 1, 1, 1), DateTime.MaxValue));
