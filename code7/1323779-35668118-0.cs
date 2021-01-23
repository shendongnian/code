    public static string Format(object value, string format, IFormatProvider formatProvider = null)
    {
        if (value == null)
        {
            return string.Empty;
        }
        IFormattable formattable = value as IFormattable;
        if (formattable != null)
        {
            return formattable.ToString(format, formatProvider);
        }
        throw new ArgumentException("value");
    }
