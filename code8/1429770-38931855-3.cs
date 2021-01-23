    var tZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(tZone);
    var p = context.tbl_prchs
        .Where(...)
        .Select(x => new NotificationViewModel(tZoneInfo)
        {
            ....
            CDate = x.c_date
        }).ToList();
