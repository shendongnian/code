    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-au", false);
    System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern.Dump();
    System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthDayPattern.Dump();
    DateTime.Parse("1/5").Dump();
    System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthDayPattern = "d MMMM";
    DateTime.Parse("1/5").Dump();
