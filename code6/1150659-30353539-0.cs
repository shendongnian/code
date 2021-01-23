    DateTime time;
    if (DateTime.TryParseExact("05/20/15", "MM/dd/yy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
    {
       do something ...
    }
