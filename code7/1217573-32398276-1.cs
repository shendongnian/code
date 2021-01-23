    public static IEnumerable<int> DaysInMonth(int year, int month, DayOfWeek dow)
    { 
        DateTime monthStart = new DateTime(year, month, 1);
        return Enumerable.Range(0, DateTime.DaysInMonth(year, month))
            .Select(day => monthStart.AddDays(day))
            .Where(date => date.DayOfWeek == dow)
            .Select(date => date.Day);
    }
