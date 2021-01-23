    private int GetWeek(DateTime date)
    {
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        Calendar cal = dfi.Calendar;
        var weeknum= cal.GetWeekOfYear(date, dfi.CalendarWeekRule, DayOfWeek.Friday);
        if (date.TimeOfDay.Hours<10)
        {
            weeknum -= 1;
        }
        return weeknum;
    }
