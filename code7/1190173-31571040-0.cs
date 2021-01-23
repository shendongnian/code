    public static bool IsBetween(this DayOfWeek weekday, DayOfWeek inclusiveStart, DayOfWeek inclusiveEnd)
    {
        if (inclusiveStart <= inclusiveEnd)
        {
            return (weekday >= inclusiveStart) && (weekday <= inclusiveEnd);
        }
        return (weekday >= inclusiveStart) || (weekday <= inclusiveEnd);
    }
