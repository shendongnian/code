    public DateTime AddBusinessDays(DateTime date, int n, IEnumerable<DayOfWeek> businessDays)
    {
        var days = new HashSet<DayOfWeek>(businessDays);
    
        // add full weeks
        date = date.AddDays(7 * n / days.Count);
    
        // get the remainder
        n %= days.Count;
    
        // add the remaining days; at most 6 times
        while (n > 0)
        {
            date = date.AddDays(1);
            if (days.Contains(date.DayOfWeek))
                n--;
        }
    
        return date;
    }
