    /// <summary>
    /// Returns the first occurrence of the specified weekday following (or on) the current System.DateTime object.
    /// </summary>
    /// <param name="currentDate">The current date</param>
    /// <param name="dayOfWeek">The weekday to find</param>
    /// <param name="includeCurrentDate">Include the current date as a valid result</param>
    /// <returns>The first date of the weekday after (or on) the current System.DateTime object.</returns>
    public static DateTime NextWeekday(this DateTime currentDate, DayOfWeek dayOfWeek, bool includeCurrentDate)
    {
        int daysInWeek = 7;
        int offset = includeCurrentDate ? 0 : 1;
        int days = (dayOfWeek - currentDate.AddDays(offset).DayOfWeek + daysInWeek) % daysInWeek;
        return currentDate.AddDays(days + offset);
    }
