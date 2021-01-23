        TimeSpan eTs = new TimeSpan(23, 30, 00);
        double inMins;
        if (DateTime.Now.TimeOfDay < eTs)
        {
            DateTime dTarget = DateTime.Now.AddDays(-1).Date + eTs;
            TimeSpan ts = DateTime.Now.Subtract(dTarget);
            inMins = ts.TotalMinutes;
        }
        else
        {
            DateTime dTarget = DateTime.Now.Date + eTs;
            TimeSpan ts = DateTime.Now.Subtract(dTarget);
            inMins = ts.TotalMinutes;
        }
