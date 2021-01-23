    // Get the time zone info
    var tZone = context.tbl_usrs.AsNoTracking().......'
    var tZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(tZone);
    // Generate the view model
    var p = context.tbl_prchs
        .Where(...)
        .ToList() // materialize query in in-memory set
        .Select(x => new NotificationViewModel()
        {
            ....
            Moment = TimeZoneInfo.ConvertTimeFromUtc(x.c_date, tZoneInfo);
        }).ToList();
