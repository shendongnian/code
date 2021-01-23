    var flag = DayOfWeekFlag.Saturday | DayOfWeekFlag.Sunday;
    var fromDate = new DateTime(2015, 1, 1);
    var toDate = new DateTime(2015, 2, 15);
    var dates = Enumerable.Range(0, (int)(toDate - fromDate).TotalDays + 1)
    	.Select(i => fromDate.AddDays(i))
    	.Where(i => flag.HasFlag(ConvertDayOfWeek(i.DayOfWeek)));
    
    
    foreach(var date in dates)
    {
    	Console.WriteLine("{0:yyyy-MM-dd ddd}", date);
    }
    
