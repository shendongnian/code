    DateTime reference = new DateTime(2015,11,20); 
    DateTime lastSaturday  = reference ;
    do 
    {
        lastSaturday = lastSaturday.AddDays(-1) ; 
    }
    while(lastSaturday.DayOfWeek != DayOfWeek.Saturday); 
 
    Console.WriteLine(lastSaturday.ToString("dd-MMM-yyyy")) ;
    // Should print 14-Nov-2015
