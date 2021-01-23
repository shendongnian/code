    var Holidays = new List<DateTime>();
    Holidays.Add(new DateTime(DateTime.Now.Year, 1, 1));
    Holidays.Add(new DateTime(DateTime.Now.Year, 1, 5));
    Holidays.Add(new DateTime(DateTime.Now.Year, 3, 10));
    Holidays.Add(new DateTime(DateTime.Now.Year, 12, 25));
    
    var exclude = new List<DayOfWeek> {DayOfWeek.Saturday, DayOfWeek.Sunday};
    
    var datesAhead = Enumerable.Range(1, 100)
      .Select( i => DateTime.Today.AddDays(i) );
      
    var targetDate = new DateTime(2015, 12, 24);
    
    
    var myDate = datesAhead
      .First(a => a > targetDate && 
      !( exclude.Contains( a.DayOfWeek ) || 
         Holidays.Contains(a)) );
