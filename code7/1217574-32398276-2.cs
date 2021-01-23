    public static IEnumerable<int> DaysInMonthMicroOptimized(int year, int month, DayOfWeek dayOfWeek)
    {
        DateTime monthStart = new DateTime(year, month, 1);
        int distanceToDayOfWeek = (dayOfWeek < monthStart.DayOfWeek ? 7 : 0) + dayOfWeek - monthStart.DayOfWeek;
        DateTime dayOfWeekInMonth = monthStart.AddDays(distanceToDayOfWeek);
        yield return dayOfWeekInMonth.Day;
        while((dayOfWeekInMonth = dayOfWeekInMonth.AddDays(7)).Month == month)
            yield return dayOfWeekInMonth.Day;
    }
