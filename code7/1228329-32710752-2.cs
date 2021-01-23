    var clock = SystemClock.Instance; // Or inject it, preferrably
    // Note that this *could* throw an exception. You could use
    // DateTimeZoneProviders.Bcl.GetSystemDefault() to use the Windows
    // time zone database.
    var zone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
    var now = clock.Now.InZone(zone);
    if (now.TimeOfDay < new LocalTime(11, 0))
    {
        ...
    }
