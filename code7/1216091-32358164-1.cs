    DateTime StartDate = new DateTime(2015, 9, 2);
    DateTime EndDate = StartDate.AddDays(duration/5*7+duration%5);
    if ( EndDate.DayOfWeek == DayOfWeek.Saturday ) {
        EndDate.AddDays(2);
    } else {
        EndDate.AddDays(1);
    }
    
