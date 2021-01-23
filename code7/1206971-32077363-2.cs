    DateTime startDate = DateTime.Now.AddMonths(-(timeFrame));
    var grouped = db.VersionBuilds
                    .Where(r => r.product_id == id && r.date > startDate)
                    .GroupBy(r => new { r.date.Year, r.date.Month })
                    .Select(r => new Data
                    { 
                        Year = r.Key.Name,
                        Month = r.Key.Month,
                        MonthName = getMonthName(r.Key.Month), 
                        TotalIssues = r.Sum(zz => zz.AcrolinxReport.total_issues) 
                    }).ToList();
    foreach(var month in monthsInTimeFrame)
    {
        if(!grouped.Any(item=>item.Year==month.Year &&
                              item.Month==month.Month) 
        grouped.Add(new Data
        { 
            Year = month.Year, 
            Month = month.Month,
            MonthName = getMonthName(month.Month), 
            TotalIssues = 0 
        });
    }
    return grouped;
  
