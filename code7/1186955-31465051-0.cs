    Week Bind(WeekDays days)
    {
         var w = new Week();
         w.Monday = (days & WeekDays.Monday) == WeekDays.Monday;
         w.Tuesday = days.HasFlag(WeekDays.Tuesday);
         w.Wednesday = (days & WeekDays.Wednesday) == WeekDays.Wednesday;
         w.Thursday = days.HasFlag(WeekDays.Thursday);
         w.Friday = (days & WeekDays.Friday) == WeekDays.Friday;
         w.Saturday = days.HasFlag(WeekDays.Saturday);
         w.Sunday = days.HasFlag(WeekDays.Sunday);
    }
