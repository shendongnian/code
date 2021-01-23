    public TimesheetWeeklyTableVM(DateTime weekEnding)
    {
        DaysOfWeek = new List<TimesheetDailyVM>();
        DateTime startDate = weekEnding.AddDays(-6);
        for(int i = 0; i < 6; i++)
        {
            DaysOfWeek.Add(new TimesheetDailyVM()
            {
                Date = startDate.AddDays(i)
            };
        }
    }
