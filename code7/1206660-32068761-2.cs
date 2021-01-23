    @{   
    System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
    System.Globalization.DateTimeFormatInfo dtinfo = ci.DateTimeFormat;
    dtinfo.AbbreviatedDayNames = new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
     }
