    ....
    var tZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(tZone);
    var p = context.tbl_prchs
        .Where(...)
        .Select(x => new NotificationViewModel()
        {
            ....
            CDate = x.c_date,
            TimeZoneInfo = tZoneInfo
        }).ToList();
