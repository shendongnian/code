    DateTime nextAnniversary;
    if (StartDate.IsLeapYear && StartDate.Month == 2 && StartDate.Day == 29)
    { 
        // or DateTime(DateTime.Today.Year, 2, 28)
        nextAnniversary = new DateTime(DateTime.Today.Year, 3, 1);
    }      
    else
    {
        nextAnniversary = 
                   new DateTime(DateTime.Today.Year, StartDate.Month, StartDate.Day);
    }
    int anniversaryYear = nextAnniversary.Year - DateTime.Now.Year;    
    if (nextAnniversary == DateTime.Now)
    {
        return anniverasryYear + " year milestone";
    }
    if (DateTime.Now > nextAnniverasry)
    {
        nextAnniversary = 
                 new DateTime(DateTime.Now.Year + 1, StartDate.Month, StartDate.Day);
        anniverasryYear++;
    }
 
    var daysTillNext = Math.Abs( (nextAnniversary - DateTime.Now).TotalDays );     
    return string.Format("{0} milestone in {1}", anniversaryYear, daysTillNext); 
    
