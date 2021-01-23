    public DateTime FollowingHour(DateTime start, int hour)
    {
        DateTime atHour = new DateTime(
            start.Year, 
            start.Month,
            start.Day,
            hour,
            0,
            0,
            0);
            
        if(atHour < start)
        {
            atHour += TimeSpan.FromDays(1);
        }
        
        return atHour;
    }
