    public static DateTime? TryGetDateTime(this string item, DateTimeFormatInfo dfi, params string[] allowedFormats)
    {
        if (dfi == null) dfi = DateTimeFormatInfo.InvariantInfo;
        DateTime dt;
        bool success;
        if(allowedFormats == null)
            success = DateTime.TryParse(item, dfi, DateTimeStyles.None, out dt);
        else
            success = DateTime.TryParseExact(item, allowedFormats, dfi, DateTimeStyles.None, out dt);
        if (success) return dt;
        return null;
    }
