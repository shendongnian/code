    // rewrite local timezone
    var tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    var fInfo = typeof(TimeZoneInfo).GetField("s_cachedData", BindingFlags.Static|BindingFlags.NonPublic);
    var cachedData = fInfo.GetValue(null);
    fInfo = cachedData.GetType().GetField("m_localTimeZone", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    fInfo.SetValue(cachedData, tz);
