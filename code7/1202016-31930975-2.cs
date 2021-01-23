    DateTime dt = new DateTime(2016, 1, 1);
    LocalDate ldt = LocalDate.FromDateTime(dt); // 2.0
    DateTimeZone tz = DateTimeZoneProviders.Tzdb["America/New_York"];
    LocalDate today = SystemClock.Instance.InZone(tz).GetCurrentDate();  // 2.0
    Period period = Period.Between(today, ldt, PeriodUnits.YearMonthDay);
    int years = (int)period.Years;
    int months = (int)period.Months;
    int days = (int)period.Days;
