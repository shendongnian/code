    for (var i = 6; i >= 0; i--)
    {
        DaysOfWeek.Add(new TimesheetDailyVM()
        {
            CurrentDate = weekEndingDate.AddDays(-i)
        });
    }
