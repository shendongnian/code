    public static DateTime AddWorkingDays(int workingDays, DateTime startDate)
    {
        var workDaysQuery = from n in Enumerable.Range(0, (workingDays + 14) * 2)
                            let date = startDate.AddDays(n)
                            where (date.DayOfWeek != DayOfWeek.Sunday)
                            && (date.DayOfWeek != DayOfWeek.Saturday)
                            select date.Date; //Remove the time component
        //The following change is not need if you know for sure that 
        //values returned by GetPublicHolidays() will not include a time component
        var publicHolidays = GetPublicHolidays().Select(x => x.Date);
    
        var daysWorking = workDaysQuery.Except(publicHolidays).ToArray(); 
    
        return daysWorking.Skip(workingDays).First();
    }
