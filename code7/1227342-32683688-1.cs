    public static DateTime FromJulian(double julianDate)
    {
      return new DateTime(
        (long)((julianDate - 1721425.5) * TimeSpan.TicksPerDay),
        DateTimeKind.Utc);
    }
