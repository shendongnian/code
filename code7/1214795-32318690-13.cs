    public static IEnumerable<DateTime> BusinessDaysOfMonth(DateTime time)
    {
        var month = new DateTime(time.Year, time.Month, 1);
        var nextMonth = month.AddMonths(1);
        var current = month;
        while(current < nextMonth)
        {
            if (IsWeekday(current) && !IsHoliday(current))
            {
                yield return current;
            }
            current = current.AddDays(1);
        }
    }
