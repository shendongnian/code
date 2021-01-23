    public DateTime AddBusinessDays(DateTime dateTime, int n, IEnumerable<DayOfWeek> businessDays)
    {
        var tmpDate = dateTime;
    
        var bdLookup = new HashSet<DayOfWeek>(businessDays); 
        while (n > 0)
        {
            tmpDate = tmpDate.AddDays(1);
            if (bdLookup.Contains(tmpDate.DayOfWeek))
                n--;
        }
    
        return tmpDate;
    }
