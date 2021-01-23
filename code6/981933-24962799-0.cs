    public static IEnumerable<DateTime> GetWeekends(DateTime startDate, DateTime endDate)
    {
        startDate = startDate.Date;
        endDate = endDate.Date;
        if (endDate < startDate)
            yield break;
        var currentDate = startDate;
        // Advance to next Saturday
        switch (currentDate.DayOfWeek)
        {
            case DayOfWeek.Saturday:
                break;
            case DayOfWeek.Sunday:
                yield return currentDate;
                currentDate = currentDate.AddDays(6);
                break;
            default:
                currentDate = currentDate.AddDays(DayOfWeek.Saturday - currentDate.DayOfWeek);
                break;
        }
        while (currentDate <= endDate)
        {
            yield return currentDate;
            currentDate = currentDate.AddDays(1);
            if (currentDate <= endDate)
                yield return currentDate;
            currentDate = currentDate.AddDays(6);
        }
    }
