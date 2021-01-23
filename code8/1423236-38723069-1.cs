    public DateTime FollowingHour(DateTime start, int hour)
    {
        DateTime atHour = start.Date.AddHours(6);
            
        if(atHour < start)
        {
            atHour += TimeSpan.FromDays(1);
        }
        
        return atHour;
    }
