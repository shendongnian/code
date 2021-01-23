    var data = ranges
        .SelectMany(r => GetMonthlyDates(r.From, r.To)
            .Select(m => new
            {
                r.ID,
                MonthName = m.ToString("MMM"),
                Days = m.Year == r.From.Year && m.Month == r.From.Month
                    ? DateTime.DaysInMonth(m.Year, m.Month) - m.Day
                    : (m.Year == r.To.Year && m.Month == r.To.Month ? r.To.Day : DateTime.DaysInMonth(m.Year, m.Month))
            }));
    private static IEnumerable<DateTime> GetMonthlyDates(DateTime from, DateTime to)
    {
        for (DateTime current = from; current.Year < to.Year || current.Month <= to.Month; current = current.AddMonths(1))
            yield return current;
    }
