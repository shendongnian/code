    foreach(var month in monthsInTimeFrame)
    {
        // If there isn't any item in the list called
        // grouped with the same year and month of the current month,
        // we have to add a new item in this list       
        if(!grouped.Any(item=>item.Year==month.Year &&
                              item.Month==month.Month)) 
            grouped.Add(new Data
            { 
                Year = month.Year, 
                Month = month.Month,
                MonthName = getMonthName(month.Month), 
                TotalIssues = 0 
            });
    }
    return grouped;
