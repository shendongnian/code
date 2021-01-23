    // Assume 'timeframe' is a positive integer.
    
    // Get the start date.
    DateTime startDate = DateTime.Now.AddMonths(-timeframe);
    
    // Generate a list of months (year and month, actually) beginning 
    // with the month of 'startDate'.
    var months =
    	Enumerable
    	.Range(0, timeframe)
    	.Select(x => startDate.AddMonths(x))
    	.Select(x => new { x.Year, x.Month });
    
    // Create builds query.
    var builds =
    	db.VersionBuilds
    	.Where(r => r.product_id == id && r.date > startDate)
    	.GroupBy(r => new { r.date.Year, r.date.Month })
    	.Select(r => new { 
    		Month = r.Key.Month,
    		Year = r.Key.Year,
    		TotalIssues = r.Sum(zz => zz.AcrolinxReport.total_issues));
    // Join 'months' on 'builds'
    var grouped =
    	months
    	.GroupJoin(
    		builds.AsEnumerable(),
    		date => date,
    		build => new { build.Year, build.Month },
    		(date, buildGroup) => new { 
                date.Year, 
                date.Month, 
                TotalIssues = buildGroup.Sum(x => x.TotalIssues) })
    	.OrderBy(x => x.Year)
    	.ThenBy(x => x.Month)
    	.Select(x => new { Month = getMonth(x.Month), x.TotalIssues });
