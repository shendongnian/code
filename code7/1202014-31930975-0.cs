    // assuming you start with a DateTime, perhaps from a db.
    DateTime dt = new DateTime(2016,1,1);
    LocalDate ldt = LocalDateTime.FromDateTime(dt).Date;
    DateTimeZone tz = DateTimeZoneProviders.Tzdb["America/New_York"];
    ZonedDateTime now = SystemClock.Instance.Now.InZone(tz);
    LocalDate today = now.Date;
    Period period = Period.Between(today, ldt, PeriodUnits.YearMonthDay);
    int years = (int) period.Years;
    int months = (int) period.Months;
    int days = (int) period.Days;
