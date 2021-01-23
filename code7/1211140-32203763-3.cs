    public static DateTime? TryGetDateTime(this string item, DateTimeFormatInfo dfi, params string[] allowedFormats)
    {
        if (dfi == null) dfi = DateTimeFormatInfo.InvariantInfo;
        DateTime dt;
        bool success = DateTime.TryParseExact(item, allowedFormats, dfi, DateTimeStyles.None, out dt);
        if (success) return dt;
        return null;
    }
