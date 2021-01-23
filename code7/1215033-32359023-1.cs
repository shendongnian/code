    TimeZoneInfo tzAtlantic = TimeZoneInfo.FindSystemTimeZoneById("Atlantic Standard Time");
    TimeZoneInfo tzIndian = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTimeOffset original = DateTimeOffset.Parse("2015-09-01T03:30:00+05:30");
    DateTimeOffset atlantic = TimeZoneInfo.ConvertTime(original, tzAtlantic);
    DateTimeOffset indian = TimeZoneInfo.ConvertTime(atlantic, tzIndian);
