    positions.Sort((x, y) =>
    {
        var xDate = getActualDate(x.FullDate, x.Year, x.Month);
        var yDate = getActualDate(y.FullDate, y.Year, y.Month);
        if (xDate == yDate && x.Id == y.Id)
        {
            return 0;                                              
        }                                    
        if (xDate > yDate)
        {
            return 1;
        }
        if (xDate == yDate && x.Id> y.Id)
        {
            return 1;                                              
        }                                    
        return -1;
    });
