    var returnDate = System.DateTime.Now.ToUniversalTime();
    var tRules = TimeZoneInfo.Local.GetAdjustmentRules().ToList();
    var rule = tRules.OrderBy(x => x.DateEnd).FirstOrDefault();
    var timeSpan = rule.DaylightDelta;
    if (timeSpan != null)
    {
        returnDate = returnDate + timeSpan;
    }
