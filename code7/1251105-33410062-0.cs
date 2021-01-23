    public static DateTime myDate(double unixTime)
    {
        System.DateTime dt = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
        return dt.AddSeconds(unixTime).ToLocalTime();
    }
