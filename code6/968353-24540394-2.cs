    public static DateTime ConvertPersianToEnglish(string persianDate)
    {
        string[] formats = { "yyyy/MM/dd", "yyyy/M/d", "yyyy/MM/d", "yyyy/M/dd" };
        DateTimeFormatInfo persianDateTimeFormatInfo = new CultureInfo("fa-Ir").DateTimeFormat;
        PersianCultureHelper.FixPersianDateTimeFormat(persianDateTimeFormatInfo, true);
        return DateTime.ParseExact(persianDate, formats, persianDateTimeFormatInfo, DateTimeStyles.None);
    }
