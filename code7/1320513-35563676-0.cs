    var result = tIncidentReportings
        .AsEnumerable()
        .GroupBy(c => c.Date.ToString("MMM"))
        .Select(g => new { Month = g.Key, Count = g.Count() })
        .OrderBy(x => DateTime.ParseExact((x.Month).ToString(), "MMM", CultureInfo.InvariantCulture));
    months.foreach(m => {
        if(!results.Select(r => r.Month).Contains(m)){
            results.Add(new {Month = m, Count = 0};
    });
