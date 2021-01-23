    private static DateTime GetFourthWednesday()
    {
        DateTime firstOfMonth = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 1);
        int count = 0;
        while (count < 4)
        {
            if (firstOfMonth.DayOfWeek == DayOfWeek.Wednesday)
            {
                count++;
            }
            if (count == 4)
            {
                return firstOfMonth;
            }
                
            firstOfMonth = firstOfMonth.AddDays(1);
        }
        return firstOfMonth;
    }
