    public static DateTime? TryGetDateTime(this string item, IFormatProvider provider = null)
    {
        if (provider == null) provider = CultureInfo.CurrentCulture;
        DateTime dt;
        bool success = DateTime.TryParse(item, provider, DateTimeStyles.None, out dt);
        if (success) return dt;
        return null;
    }
