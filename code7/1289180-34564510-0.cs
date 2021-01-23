    public static bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
    {
        Int32 result;
        return Int32.TryParse(val, NumberStyle,
            System.Globalization.CultureInfo.CurrentCulture, out result);
    }
