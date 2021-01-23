    public int WeekNumber(DateTime date)
    {          
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        System.Globalization.Calendar cal = dfi.Calendar;
        return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }
