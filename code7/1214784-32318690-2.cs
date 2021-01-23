    public static bool IsFirstThreeDays(DateTime time) => time.Day < 4;
    public static bool IsWeekday(DateTime time)
    {
        var dow = time.DayOfWeek;
        return dow != DayOfWeek.Saturday && dow != DayOfWeek.Sunday;
    }
    public bool IsHoliday(DateTime time)
    {
        ISet<DateTime> holidays = ??; // Decide whether this is a member or an arg
        return holidays.Contains(time.Date);
    }
