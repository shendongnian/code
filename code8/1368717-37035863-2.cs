    public TimesheetWeeklyTableVM(DateTime date)
    {
        DateTime firstDay = Helpers.GetFirstDayOfWeek(date);
        DaysOfWeek = new List<TimesheetDailyVM>();
        for(int i=0; i<7; i++){
            DaysOfWeek.Add(new TimesheetDailyVM()
            {
                MyCurrentDay = firstDay.AddDays(i);
            });
        }
    }
