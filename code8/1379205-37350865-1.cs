    public static void Print(FormattableString s)
    {
        Console.WriteLine("norwegian: " + s.ToString(CultureInfo.GetCultureInfo("nb-NO")));
        Console.WriteLine("us: " + s.ToString(CultureInfo.GetCultureInfo("en-US")));
        Console.WriteLine("swedish: " + s.ToString(CultureInfo.GetCultureInfo("sv-SE")));
    }
