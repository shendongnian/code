    DateTime date;
    string fmt = "MMM dd, yyyy hh:mm:ss:fff tt";
    Console.WriteLine(DateTime.TryParseExact("May 21, 2015 12:25:35:719 AM", fmt, new CultureInfo("en-US"), DateTimeStyles.None, out date));
    CultureInfo dutch = new CultureInfo("nl-BE");
    String s = date.ToString(fmt, dutch);
    Console.WriteLine(s);
    Console.WriteLine(DateTime.TryParseExact(s, fmt, dutch, DateTimeStyles.None, out date));
