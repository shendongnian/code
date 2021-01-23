    var months = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames.Select(s => s.Substring(0,3)).ToList();
    var reports = months.Select(m => 
        new { 
            Month = m, 
            Count = tIncidentReportings.AsEnumerable().Where(i => i.Date.ToString("MMM") == m).Count()
        }
    ).OrderBy(x => DateTime.ParseExact((x.Month).ToString(), "MMM", CultureInfo.InvariantCulture)).ToList();
