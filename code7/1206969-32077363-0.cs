    // First, we create a list with all months in the given time frame
    // For instance, if we run this now and set as a timeFrame to be 3, then 
    // This list would contain the following datetimes
    // 2015-08-15 ...., 2015-07-15 ...., 2015-06-15
    var monthsInTimeFrame = new List<DateTime>();
    for(int i = timeFrame; i>=0 ; i--)
    { 
        monthsInTimeFrame.Add(DateTime.Now.AddMonths(-i));
    }
    DateTime startDate = DateTime.Now.AddMonths(-(timeFrame));
    var grouped = db.VersionBuilds
                    .Where(r => r.product_id == id && r.date > startDate)
                    .GroupBy(r => new { r.date.Year, r.date.Month })
                    .Select(r => new { 
                        year = r.Key.Name,
                        month = r.Key.Month,
                        monthName = getMonthName(r.Key.Month), 
                        totalIssues = r.Sum(zz => zz.AcrolinxReport.total_issues) 
                    }).ToList();
    foreach(var month in monthsInTimeFrame)
    {
        if(!grouped.Any(item=>item.year==month.Year &&
                              item.month==month.Month) 
        grouped.Add(new { 
            year = month.Year, 
            month = month.Month,
            monthName = getMonthName(month.Month), 
            0 
        });
    }
    return grouped;
  
