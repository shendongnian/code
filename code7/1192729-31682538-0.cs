    public static DateTime GetCurrentEasternTime()
    {
        // The current rule for US Eastern Time is:
        //   -5 => -4: 2nd Sunday in March    (2:00 AM Local Time, 7:00 AM UTC)   
        //   -4 => -5: 1st Sunday in November (2:00 AM Local Time, 6:00 AM UTC)
    
        DateTime utcNow = DateTime.UtcNow;
    
        DateTime springTransitionUtc = new DateTime(utcNow.Year, 3, 8, 7, 0, 0);
        while (springTransitionUtc.DayOfWeek != DayOfWeek.Sunday)
            springTransitionUtc = springTransitionUtc.AddDays(1);
    
        DateTime fallTransitionUtc = new DateTime(utcNow.Year, 11, 1, 6, 0, 0);
        while (fallTransitionUtc.DayOfWeek != DayOfWeek.Sunday)
            fallTransitionUtc = fallTransitionUtc.AddDays(1);
    
        bool isDst = utcNow >= springTransitionUtc && utcNow < fallTransitionUtc;
    
        int offset = isDst ? -4 : -5;
    
        DateTime easternNow = utcNow.AddHours(offset);
    
        return easternNow;
    }
