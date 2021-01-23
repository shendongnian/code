    var zonedClock = SystemClock.Instance.InTzdbSystemDefaultZone();
    if (zonedClock.GetCurrentTimeOfDay() < new LocalTime(11, 0))
    {
        ...
    }
