    DateTime fromDate = new DateTime(2015, 1, 1);
    DateTime toDate = new DateTime(2015, 2, 15);
    DateTime[] dates = Enumerable.Range(0, (int)toDate.Subtract(fromDate).TotalDays + 1)
        .Select(i => fromDate.AddDays(i))
        .Where(i => (i.DayOfWeek == DayOfWeek.Monday || i.DayOfWeek == DayOfWeek.Sunday)).ToArray();
    
    
    foreach(DateTime date in dates)
    {
        Console.WriteLine("{0:yyyy-MM-dd ddd}", date);
    }
