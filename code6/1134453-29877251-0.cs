    int _campingDaysAdj = 30 - campingDays;
    if(_campingDaysAdj > 0 && pagesPerDay > 0)
    {
        int months = page / ((30 - campingDays) * pagesPerDay);
        int years = months / 12;
        int remainingMonths = months % 12;
        Console.WriteLine("{0} years {1} months", years, remainingMonths);
    }
    else
    {
        //throw an exception or an error message etc.
    }
