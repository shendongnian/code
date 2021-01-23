    public static bool IsDayWhatYouWant()
    {
        var now = DateTime.Now;
        return IsFirstThreeDays(now) && IsWeekday(now) && !IsHoliday(now);
    }
