    public static bool IsFirstThreeBusinessDays(DateTime date, HashSet<DateTime> holidays)
    {
        var query =
            Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
                .Select(o => new DateTime(date.Year, date.Month, o))
                .Where(o => o.DayOfWeek != DayOfWeek.Saturday && o.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Contains(o))
                .Take(3);
        return query.Contains(date);
    }
