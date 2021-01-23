    public static bool IsDayWhatYouWant()
    {
        var now = DateTime.UtcNow;
        return IsFirstThreeDays(now) && IsWeekday(now) && !IsHoliday(now);
    }
