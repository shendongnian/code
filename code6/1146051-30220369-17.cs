    // We use this function because .NET does not implicitly consider the first and last weeks of the year the same.
    public static int GetWeekOfYear(int weekNumber)
    {
        if (weekNumber > 52)
            return 1;
        return weekNumber;
    }
    // This will get the week-range in a string of format "yyyy-MM-dd - yyyy-MM-dd".
    public static string GetWeekRange(DateTime date, DayOfWeek firstDayOfWeek)
    {
        int numberOfDayOfWeek = DayOfWeekToNumber(date.DayOfWeek, firstDayOfWeek);
        return date.AddDays(0 - numberOfDayOfWeek).ToString("yyyy-MM-dd") + " - " + date.AddDays(6 - numberOfDayOfWeek).ToString("yyyy-MM-dd");
    }
    // This converts the DayOfWeek to a number to allow us to easily determine how many days to add/subtract for the first/last days of the week.
    public static int DayOfWeekToNumber(DayOfWeek dayOfWeek, DayOfWeek firstDayOfWeek)
    {
        int[] r = new int[2];
        r[0] = 0;
        r[1] = 0;
        r[0] = DayOfWeekValue(firstDayOfWeek);
        r[1] = DayOfWeekValue(dayOfWeek);
        int result = r[1] - r[0];
        if (result < 0)
            result += 7;
        return result;
    }
    // This converts the DayOfWeek enum into a numerical value, Sunday being 0 and up from there.
    public static int DayOfWeekValue(DayOfWeek dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeek.Sunday:
                return 0;
            case DayOfWeek.Monday:
                return 1;
            case DayOfWeek.Tuesday:
                return 2;
            case DayOfWeek.Wednesday:
                return 3;
            case DayOfWeek.Thursday:
                return 4;
            case DayOfWeek.Friday:
                return 5;
            case DayOfWeek.Saturday:
                return 6;
        }
        return -1;
    }
