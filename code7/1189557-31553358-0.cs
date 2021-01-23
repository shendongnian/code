    public static string FormatDecimal(decimal d)
    {
        string s = d.ToString("0.00##", NumberFormatInfo.InvariantInfo).Replace(".", ",");
        if (s.EndsWith(",00", StringComparison.Ordinal))
            s = s.Substring(0, s.Length - 2);
        return s;
    }
