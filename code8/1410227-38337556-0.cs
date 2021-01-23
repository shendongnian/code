    DateTime GetNextLeapDate (DateTime baseTime)
    {
        int year = baseTime.Year;
        
        // start in the next year if we’re already in March
        if (baseTime.Month > 2)
            year++;
        // find next leap year
        while (!DateTime.IsLeapYear(year))
            year++;
        
        // get last of February
        return new DateTime(year, 2, 29);
    }
