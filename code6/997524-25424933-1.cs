    public static string GetAbbreviatedFromFullName(string fullname)
    {
        DateTime month;
        return DateTime.TryParseExact(
                fullname,
                "MMMM",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out month)
            ? month.ToString("MMM")
            : null;
    }
