    bool IsWorkingDay(DateTime dt)
    {
        int year = dt.Year;
        Dictionary<DateTime, object> holidays = new Dictionary<DateTime, object>();
        holidays.Add(new DateTime(year, 1, 1), null);
        holidays.Add(new DateTime(year, 1, 6), null);
        holidays.Add(new DateTime(year, 4, 25), null);
        holidays.Add(new DateTime(year, 5, 1), null);
        holidays.Add(new DateTime(year, 6, 2), null);
        holidays.Add(new DateTime(year, 8, 15), null);
        holidays.Add(new DateTime(year, 11, 1), null);
        holidays.Add(new DateTime(year, 12, 8), null);
        holidays.Add(new DateTime(year, 12, 25), null);
        holidays.Add(new DateTime(year, 12, 26), null);
        DateTime easterMonday = EasterSunday(year).AddDays(1);
        if (!holidays.ContainsKey(easterMonday))
            holidays.Add(easterMonday, null);
        if (!holidays.ContainsKey(dt.Date))
            if (dt.DayOfWeek > DayOfWeek.Sunday && dt.DayOfWeek < DayOfWeek.Saturday)
                return true;
        return false;
    }
    string WorkingTime(DateTime dt1, DateTime dt2)
    {
        // Adjust begin datetime
        if (IsWorkingDay(dt1))
        {
            if (dt1.TimeOfDay < TimeSpan.FromHours(9))
                dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, 9, 0, 0);
            else if (dt1.TimeOfDay > TimeSpan.FromHours(13) && dt1.TimeOfDay < TimeSpan.FromHours(14))
                dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, 14, 0, 0);
            else if (dt1.TimeOfDay > TimeSpan.FromHours(18))
                dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, 9, 0, 0).AddDays(1);
        }
        else
            dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, 9, 0, 0).AddDays(1);
        // Adjust end datetime
        if (IsWorkingDay(dt2))
        {
            if (dt2.TimeOfDay < TimeSpan.FromHours(9))
                dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 18, 0, 0).AddDays(-1);
            else if (dt2.TimeOfDay > TimeSpan.FromHours(18))
                dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 18, 0, 0);
            else if (dt2.TimeOfDay > TimeSpan.FromHours(13) && dt2.TimeOfDay < TimeSpan.FromHours(14))
                dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 13, 0, 0);
        }
        else
            dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, 18, 0, 0).AddDays(-1);
        double days = 0;
        double hours = 0;
        double minutes = 0;
        if (dt2 > dt1)
        {
            // Move dt1 forward to reach dt2 day chacking for working days
            while (dt1.DayOfYear < dt2.DayOfYear)
            {
                if (IsWorkingDay(dt1))
                    days++;
                dt1 = dt1.AddDays(1);
            }
            // Now get the worked hours as if were on the same day in the same manner
            TimeSpan sdwt = dt2 - dt1;
            if (dt1.TimeOfDay < TimeSpan.FromHours(13) && dt2.TimeOfDay > TimeSpan.FromHours(14))
                sdwt -= TimeSpan.FromHours(1);
            if (sdwt == TimeSpan.FromHours(8))
                days++;
            else
            {
                hours = sdwt.Hours;
                minutes = sdwt.Minutes;
            }
        }
        // There is a pause in between so adjust if the interval include it
        var totalminutes = (days * 8 * 60 + hours * 60 + minutes);
        string res = String.Format("{0} days {1} hours {2} minutes",
            days,
            hours,
            minutes);
        string totRes = String.Format("{0} days {1} hours {2} minutes",
            totalminutes / 8 / 60,
            totalminutes / 8,
            totalminutes);
        return res + "\r\n" + totRes;
    }
