    public static DateTime ZeroMilliseconds(this DateTime value) 
    {
      return new DateTime(value.Year, value.Month, value.Day, 
        value.Hours, value.Minutes, value.Seconds);
    }
