    public List<Week> GetWeeks()
    {
        var weeks = new List<Week>();
    
        var week = new Week
        {
            Start = now.AddDays((-(int)now.DayOfWeek + 1) - getDay),
            End = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6),
        }
    
        weeks.Add(week);
    
        // add more weeks
    
        return weeks;
    
    }
