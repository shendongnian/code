    public static IEnumerable<DateTime> WeekdaysOfMonth(DateTime time)
    {
        var month = new DateTime(time.Year, time.Month, 1);
        var nextMonth = month.AddMonths(1);
        var current = month;
        var count = 0;
        while(current < nextMonth && count < 3)
        {
            if (IsWeekday(current) && !IsHoliday(current))
            {
                yield return current;
                count += 1;
            }
            current = current.AddDays(1);
        }
    }
