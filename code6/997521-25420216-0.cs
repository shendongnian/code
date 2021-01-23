    string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;
    foreach (var item in names)
    {
        if (item == "agosto")
        {
           Console.WriteLine(DateTime.ParseExact(item, "MMMM", CultureInfo.CurrentCulture)
                             .ToString("MMM")));
        }
    }
