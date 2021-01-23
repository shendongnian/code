    public DateTime? StringToDate (string dateString, string dateFormat)
    {
        DateTime? dt;
        DateTime.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out dt);
        return dt;
    }
