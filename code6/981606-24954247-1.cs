    //My birthday, feel free to put this date in your calendars!
    var startDate = new DateTime(1976, 2, 29);
    
    //Get the anniversary date for this year
    DateTime nextAnniversary;
    
    try
    {
    	nextAnniversary = new DateTime(DateTime.Today.Year, startDate.Month, startDate.Day);
    }
    catch(ArgumentOutOfRangeException)
    {
        //DateTime conversion failed, try next day in the year
    	nextAnniversary = new DateTime(DateTime.Today.Year, startDate.AddDays(1).Month, startDate.AddDays(1).Day);
    }
    
    //Check if this year's anniversary has already happened
    if(nextAnniversary < DateTime.Today) nextAnniversary = nextAnniversary.AddYears(1);
