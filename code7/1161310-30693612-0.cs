    private static void Main(string[] args)
    {
        var start  = new DateTime(2015, 01, 01); // Thusday
        var finish = new DateTime(2015, 01, 31); // Saturday
        var totalDays = finish.Subtract(start).TotalDays;  // 30 days
        var test1 = GetWorkingDays(start, finish, false, new List<DateTime>()); // should be 30
        var test2 = GetWorkingDays(start, finish, true , new List<DateTime>()); // should be 21
        var test3 = GetWorkingDays(start, finish, true , new List<DateTime>     // should be 19
        {
            new DateTime(2015, 01, 01), // New Year's Day
            new DateTime(2015, 01, 09), // Random holiday
            new DateTime(2015, 01, 25), // Sao Paulo city foundation, sunday
        });
    }
    public static int GetWorkingDays(DateTime from, DateTime to, 
                                     bool skipWeekends, IEnumerable<DateTime> holidays)
    {
        var totalDays = (int)to.Subtract(from).TotalDays;
        var isHoliday = new Func<DateTime, bool>(date =>
            holidays.Contains(date));
        var isWeekend = new Func<DateTime, bool>(date => 
            date.DayOfWeek == DayOfWeek.Saturday || 
            date.DayOfWeek == DayOfWeek.Sunday);
        return Enumerable
            .Range (0, totalDays + 1)
            .Select(days => from.AddDays(days))
            .Count (date => (!skipWeekends || !isWeekend(date)) && !isHoliday(date)) - 1;
    }
