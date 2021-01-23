    @{   
    System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("");
    System.Globalization.DateTimeFormatInfo dtinfo = ci.DateTimeFormat;
    dtinfo.AbbreviatedDayNames = new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
     }
