    public static bool IsFirstThreeBusinessDays(DateTime date, HashSet<DateTime> holidays)
    {
        DateTime dt = new DateTime(date.Year, date.Month, 1);
        int businessDaysSeen = 0;
        while (businessDaysSeen < 3)
        {
            if (dt.DayOfWeek != DayOfWeek.Saturday && 
                dt.DayOfWeek != DayOfWeek.Sunday && 
                !holidays.Contains(dt))
            {
                if (dt == date)
                {
                    return true;
                }
                businessDaysSeen++;
            }
            dt = dt.AddDays(1);
        }
        return false;
    }
