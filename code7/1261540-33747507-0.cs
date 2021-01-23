    internal static DateTime MyDate
    {
        get { return DateTime.SpecifyKind(Properties.Settings.Default.MyDate, DateTimeKind.Utc); }
        set { Properties.Settings.Default.MyDate = value.ToUniversalTime(); }
    }
