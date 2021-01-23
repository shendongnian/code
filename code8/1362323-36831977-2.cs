    public static IEnumerable<DateTime> GetWeekDaysForCurrentOrNextWeek(DateTime forDate)
    {
        //Badly named variable. It's late.
        var getStartForWeek = forDate.AddHours(6).DayOfWeek > DayOfWeek.Wednesday
            ? forDate.AddDays(7) : forDate;
        return
            DateFunctions.GetDateRange(
            GetPreviousInstanceOfWeekDay(getStartForWeek, DayOfWeek.Monday), 5);
    }
    
    
