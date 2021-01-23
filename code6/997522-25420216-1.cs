    public static string GetAbbreviatedFromFullName(string fullname)
    {
        string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;
        foreach (var item in names)
        {
            if (item == fullname)
            {
                return DateTime.ParseExact(item, "MMMM", CultureInfo.CurrentCulture)
                                     .ToString("MMM");
            }
        }
        return string.Empty;
    }
