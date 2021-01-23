    DateTime date = //... (e.g. 2016-01-05)
    var result =
        entries //e.g., context.DeviceHistoryEntries
        .GroupBy(x => x.DeviceId)
        .Select(gr =>
            gr
            .Where(x => x.LastUpdatedDate < date)
            .OrderByDescending(x => x.LastUpdatedDate)
            .FirstOrDefault()) //This will give us null for devices that
                               //don't have a status entry before the date
        .AsEnumerable()
        .Where(x => x != null) //remove null values (optional)
        .ToList();
                 
