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
    public static decimal? TryGetDecimal(this string item, IFormatProvider formatProvider = null, NumberStyles nStyles = NumberStyles.Any)
    {
        if (formatProvider == null) formatProvider = NumberFormatInfo.CurrentInfo;
        decimal d = 0m;
        bool success = decimal.TryParse(item, nStyles, formatProvider, out d);
        if (success)
            return d;
        else
            return null;
    }
    public static decimal? TryGetInt32(this string item, IFormatProvider formatProvider = null, NumberStyles nStyles = NumberStyles.Any)
    {
        if (formatProvider == null) formatProvider = NumberFormatInfo.CurrentInfo;
        int i = 0;
        bool success = int.TryParse(item, nStyles, formatProvider, out i);
        if (success)
            return i;
        else
            return null;
    }
