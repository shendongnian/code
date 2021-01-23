    public static DateTime GetNextNonHolidayWeekDay(DateTime date, IList<Holiday> holidays, IList<DayOfWeek> weekendDays)
    {
        // always start with tomorrow, and truncate time to be safe
        date = date.Date.AddDays(1);
        // calculate holidays for both this year and next year
        var holidayDates = holidays.Select(x => x.GetDate(date.Year))
            .Union(holidays.Select(x => x.GetDate(date.Year + 1)))
            .Where(x=> x != null)
            .Select(x=> x.Value)
            .OrderBy(x => x).ToArray();
        // increment until we get a non-weekend and non-holiday date
        while (true)
        {
            if (weekendDays.Contains(date.DayOfWeek) || holidayDates.Contains(date))
                date = date.AddDays(1);
            else
                return date;
        }
    }
