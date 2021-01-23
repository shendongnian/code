    public DateTime GetStartOfWeek(DateTime now, int getDay, int n)
    {
        return now.AddDays((-(int)now.DayOfWeek + 1) - getDay - n*7);
    }
    public DateTime GetEndOfWeek(DateTime now, int getDay, int n)
    {
        return now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - n*7);
    }
