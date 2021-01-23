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
            
        var start = DateTime.Parse("2015-05-21 13:00:00");
        var end = DateTime.Parse("2015-06-09 22:00:00");
    
        Console.WriteLine(dates
            .Where(x => x <= start)
            .OrderByDescending(x => x)
            .FirstOrDefault()); 
        Console.WriteLine(dates
            .Where(x => x >= end)
            .OrderBy(x => x)
            .FirstOrDefault());
    }
    
    // the date must be outside of boundary, so this is no longer good...
    //public static DateTime GetClosestDate(IEnumerable<DateTime> source, DateTime date)
    //{
    //    return source
    //        .OrderBy(x => Math.Abs((x.Date - date).TotalSeconds))
    //        .First();
    //}
