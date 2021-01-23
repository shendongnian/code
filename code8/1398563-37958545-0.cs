    List<DayOfWeek> holydays = new List<DayOfWeek>() { DayOfWeek.Sunday, DayOfWeek.Saturday };
    DateTime firstDayOfMonth = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1); // first day of month
    int thirdDay = 1;
    int addDay = 0;
    while (thirdDay <= 3)
    {
        if (!holydays.Contains(firstDayOfMonth.AddDays(addDay++).DayOfWeek))
        {
            thirdDay++;
        }
    
    }
    DateTime thirdWorkingDay = firstDayOfMonth.AddDays(--addDay);
