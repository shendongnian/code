    public static int? TryGetInt32(this string item, IFormatProvider formatProvider = null, NumberStyles nStyles = NumberStyles.Any)
    {
        if (formatProvider == null) formatProvider = NumberFormatInfo.CurrentInfo;
        int i = 0;
        bool success = int.TryParse(item, nStyles, formatProvider, out i);
        if (success)
            return i;
        else
            return null;
    }
