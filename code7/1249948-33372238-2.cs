    var Holidays = new List<DateTime>();
    Holidays.Add(new DateTime(DateTime.Now.Year, 1, 1));
    Holidays.Add(new DateTime(DateTime.Now.Year, 1, 5));
    Holidays.Add(new DateTime(DateTime.Now.Year, 3, 10));
    Holidays.Add(new DateTime(DateTime.Now.Year, 12, 25));
    
    var exclude = new List<DayOfWeek> {DayOfWeek.Saturday, DayOfWeek.Sunday};
    
    var targetDate = new DateTime(2015, 12, 24);
    
    
    var myDate = Enumerable.Range(1, 30)
      .Select( i => targetDate.AddDays(i) )
      .First(a =>  
      !( exclude.Contains( a.DayOfWeek ) || 
         Holidays.Contains(a)) );
