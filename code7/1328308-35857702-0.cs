    public static List<DateTime> Get_DayofWeek_DatesBetween(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
    {
        List<DateTime> list = new List<DateTime>();
        // Dates range. "+ 1" include endDate
        double datesRange = (endDate.Date - startDate.Date).TotalDays + 1;
        // Find first "dayOfWeek" date from startDate
        int i = dayOfWeek - startDate.DayOfWeek;
        if (i < 0) i += 7;
        // Add all "dayOfWeek" dates in given range
        for (int j = i; j < datesRange; j += 7) list.Add(startDate.AddDays(j));
        return list;
    }
