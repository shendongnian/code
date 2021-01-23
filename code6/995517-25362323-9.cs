    public static DateTime ToDateTime(String value)
    {
         if (value == null)
             return new DateTime(0);
         return DateTime.Parse(value, CultureInfo.CurrentCulture);
    }
