    int anniversaryYear = DateTime.Now.Year - StartDate.Year + 1;    
    DateTime nextAnniversary = StartDate.AddYears(anniversaryYear);    
    if (nextAnniversary == DateTime.Now)
    {
        return anniverasryYear + " year milestone";
    }
    if (DateTime.Now > nextAnniverasry)
    {
        anniverasryYear++;
        nextAnniversary = StartDate.AddYears(anniversaryYear);    
    }
 
    var daysTillNext = Math.Abs( (nextAnniversary - DateTime.Now).TotalDays );     
    return string.Format("{0} milestone in {1}", anniversaryYear, daysTillNext); 
    
