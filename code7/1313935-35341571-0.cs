    public static DateTime? ToDate(this object val, IFormatProvider formatProvider = null)
    {
        if(val ==  null) return null;
        if(val is DateTime) return (DateTime) val;
        if(val is DateTime?) return (DateTime?) val;
        if(formatProvider == null) formatProvider = System.Globalization.DateTimeFormatInfo.CurrentInfo;
        string dateStr = val.ToString();
        DateTime dt;
        if(DateTime.TryParse(dateStr, formatProvider, System.Globalization.DateTimeStyles.None, out dt))
            return dt;
        return null;
    }
