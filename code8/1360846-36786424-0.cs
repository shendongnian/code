    void Main()
    {
        var dates = new string[]
            {
                "2015-03-21 13:00:00",
                "2015-05-15 13:00:00",
                "2015-05-24 13:00:00",
                "2015-05-27 13:00:00",
                "2015-06-14 13:00:00"
            }
            .Select(x => DateTime.Parse(x))
            .ToList();
        
        Console.WriteLine(GetClosestDate(dates, DateTime.Parse("2015-05-21 13:00:00"))); 
        Console.WriteLine(GetClosestDate(dates, DateTime.Parse("2015-06-09 22:00:00"))); 
    }
    
    // Define other methods and classes here
    public static DateTime GetClosestDate(IEnumerable<DateTime> source, DateTime date)
    {
        return source
            .OrderBy(x => Math.Abs((x.Date - date).TotalSeconds))
            .First();
    }
