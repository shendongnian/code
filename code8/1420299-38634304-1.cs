    DateTime zeroTime = new DateTime(1, 1, 1);
    
    DateTime a = dpkDOB.Value.Year;
    DateTime b = DateTime.Today.Year;
    
    TimeSpan span = b - a;
    
    // because we start at year 1 for the Gregorian 
    // calendar, we must subtract a year here.
    int years = (zeroTime + span).Year - 1; 
    if(years < 18)
    {
      //Show messagebox
    }
    else
    {
       // continue
    }
