    public static DateTime? TryParseExact(this string src, string format, IFormatProvider provider, DateTimeStyles style)
    {
        //do stuff
    }
    
    public static DateTime? TryParseExact(this string src, string format)
    {
        IFormatProvider provider = DateTimeFormatInfo.CurrentInfo;
        DateTimeStyles style = DateTimeStyles.None;
        return TryParseExact(src, format, provider, style);
    }
