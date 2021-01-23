    var dates = new List<DateTime>();
    dates.Add(new DateTime(2002, 01, 01));
    dates.Add(new DateTime(2002, 01, 02));
    dates.Add(new DateTime(2002, 01, 03));
    dates.Add(new DateTime(2002, 01, 04));
    dates.Add(new DateTime(2002, 01, 06));
    dates.Add(new DateTime(2002, 01, 08));
    // algo works only if dates are in order
    dates = dates.OrderBy(date => date).ToList();
    var missingDates = new List<DateTime>();
    for (int i = 0; i + 1 < dates.Count; i++)
    {
        var diff = (dates[i + 1] - dates[i]).TotalDays;
        for(int iToComplete = 1; iToComplete < diff; iToComplete++)
        {
            missingDates.Add(dates[i].AddDays(iToComplete));
        }
    }
    dates.AddRange(missingDates);
    dates = dates.OrderBy(date => date).ToList();
