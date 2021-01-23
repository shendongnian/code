    int BuinessDayCount(DateTime targetDay)
    {
        // check if the target day is a weekend
        if (targetDay.DayOfWeek == DayOfWeek.Saturday)
            return -1;
        if (targetDay.DayOfWeek == DayOfWeek.Sunday)
            return -2;
    
        // get the start of the month
        DateTime start = new DateTime(targetDay.Year, targetDay.Month, 1);
        
        // create a target without any time component
        DateTime end = targetDay.Date;
    
        int workingDays = 0;
        while (start <= targetDay)
        {
            if (start.DayOfWeek != DayOfWeek.Saturday
             && start.DayOfWeek != DayOfWeek.Sunday)
            {
                workingDays++;
            }
            start = start.AddDays(1);
        }
    
        return workingDays;
    }
