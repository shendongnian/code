    // Parse a string with a fixed +05:30 Indian offset
    // This is converting to the local time zone in the process (Kind == DateTimeKind.Local)
    var tesDate = DateTime.Parse("2015-09-01T03:30:00+05:30");
    // Get the Atlantic time zone
    TimeZoneInfo tmz = TimeZoneInfo.FindSystemTimeZoneById("Atlantic Standard Time");
    // Assign DateTimeKind.Unspecified, which removes the existing Local kind  (why?)
    DateTime tesDate1 = DateTime.SpecifyKind(tesDate, DateTimeKind.Unspecified);
    // Convert to UTC, pretending the time is in AST, when actually it's in the local zone
    var earliestStartTime = TimeZoneInfo.ConvertTime(tesDate1, tmz, TimeZoneInfo.Utc);
    // Convert from UTC back to the local zone
    var localEarliestStartTime = earliestStartTime.ToLocalTime();
