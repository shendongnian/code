    static void Main(string[] args)
    {
        TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time"));
        var foo = DateTime.Now;     
    }
