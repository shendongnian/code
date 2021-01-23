    DateTime d1 = Convert.ToDateTime("02-03-2015");
    DateTime d2 = Convert.ToDateTime("09-08-2015");
    int daysBetween = (d1 - d2).Days;
    if (daysBetween > 365)
    {
        // More then 1 year   
    }
    else
    {
        // Within 1 year
    }
