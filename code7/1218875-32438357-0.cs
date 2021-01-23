    var dateList = new List<DateTime>();
    foreach (var ld in LiveDates)
    {
        for (var dt = ld.StartDate.Date; dt <= ld.EndDate.Date; dt = dt.AddDays(1))
        {
            dateList.Add(dt);
        }
    }
    dateList = dateList.Distinct().ToList();
    dateList = dateList.Sort((a, b) => a.CompareTo(b));
