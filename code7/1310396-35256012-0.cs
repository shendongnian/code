    public static DateTime? ParseDate_MMMdyyyyhhmmtt(string date)
    {
        if (date == null)
            return null;
        if (date.Length < 14)
            return null;
        if (date.Length == 14)
            date = date.Insert(3, "0");
        DateTime dt;
        if (DateTime.TryParseExact(date, "MMMdyyyyhhmmtt",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out dt))
            return dt;
        return null;
    }
