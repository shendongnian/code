    public static DateTime ToDate(this object value)
    {
        DateTime OutputDate ;
        DateTime.TryParseExact(value, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out OutputDate);
        return OutputDate ?? DateTime.Now  ;
    }
