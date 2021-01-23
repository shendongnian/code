        // create a timeline scale
        NRangeTimelineScaleConfigurator rangeScale  = new NRangeTimelineScaleConfigurator();
        rangeScale.EnableCalendar = true;
        // create a rule
        NWeekDayRule wdr = new NWeekDayRule();
        wdr.Saturday = false;
        wdr.Sunday = false;
        // set shedule non working hours
        wdr.Schedule.SetHourRange(0, 9, true);
        wdr.Schedule.SetHourRange(12, 13, true);
        wdr.Schedule.SetHourRange(18, 24, true);
        rangeScale.Calendar.Rules.Add(wdr);
