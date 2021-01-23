    private DateTime FormatDate(string date, string format)
    {
        try
        {
            IFormatProvider culture = new CultureInfo("en-US", true);
            return DateTime.ParseExact(date, format, culture);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
