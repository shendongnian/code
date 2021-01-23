    public static DateTimeOffset Parse(string iso8601String)
    {
        return DateTimeOffset.ParseExact(
            iso8601String,
            new string[] { "yyyy-MM-dd'T'HH:mm:ss.FFFK" },
            CultureInfo.InvariantCulture,
            DateTimeStyles.None);
    }
