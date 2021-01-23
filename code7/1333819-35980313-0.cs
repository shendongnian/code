    // The date with time component
    var testDate = startDate.AddDays(i);
    
    // Get date-only portion of date, without its time (ie, time 00:00:00).
    var testDateOnly = testDate.Date;
    
    // Display date using short date string.
    Console.WriteLine(testDateOnly.ToString("d"));
    // OUTPUT will be     1/2/2016
   
