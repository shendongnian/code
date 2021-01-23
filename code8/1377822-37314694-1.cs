    public Tuple<int, int, int, int> BreakDownDateRange(DateTime fromDate, DateTime toDate)
    {
        int years = 0;
        int months = 0;
        int weeks = 0;
        int days = 0;
        DateTime remainingDate = fromDate;
        while (remainingDate.Date < toDate.Date)
        {
            var yearTest = remainingDate.Date.AddYears(1);
            if(yearTest <= toDate.Date)
            {
                years += 1;
                remainingDate = yearTest;
                continue;
            }
    
            var monthsTest = remainingDate.Date.AddMonths(1);
            if(monthsTest <= toDate.Date)
            {
                months += 1;
                remainingDate = monthsTest;
                continue;
            }
    
            var weeksTest = remainingDate.Date.AddDays(7);
            if(weeksTest <= toDate.Date)
            {
                weeks += 1;
                remainingDate = weeksTest;
                continue;
            }
    
            var daysTest = remainingDate.Date.AddDays(1);
            if(daysTest <= toDate.Date)
            {
                days += 1;
                remainingDate = daysTest;
                continue;
            }
        }
    
        return Tuple.Create(years, months, weeks, days);
    }
