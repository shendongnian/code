    public static string GetWeekRange(DateTime date, DayOfWeek firstDayOfWeek)
    {
        int numberOfDayOfWeek = DayOfWeekToNumber(date.DayOfWeek, firstDayOfWeek);
        return date.AddDays(0 - numberOfDayOfWeek).ToString("yyyy-MM-dd") + " - " + date.AddDays(6 - numberOfDayOfWeek).ToString("yyyy-MM-dd");
    }
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
