    static DateTime? FindDate(int year, int month, DayOfWeek dayOfWeek, int weekOfMonth = 5)
    {
        var baseDate = new DateTime(year, month, 1);
        int firstDateOffset = ((int)dayOfWeek - (int)baseDate.DayOfWeek + 7) % 7;
        var date = baseDate.AddDays(firstDateOffset + 7 * (weekOfMonth - 1));
        return date.Month == month ? date : (DateTime?)null; 
    }
