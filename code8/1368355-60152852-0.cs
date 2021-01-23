log.InfoFormat(CultureInfo.CurrentCulture, "Invalid date of {0} found in field {1}", date, field.Name);
Or, alternatively, You can have this proxied in your own logger class that calls log4net logger object internally with the culture:
public static class Logger
{
    ...
    public static void InfoFormat(string pattern, params object[] values)
    {
        _log4net.InfoFormat(CultureInfo.CurrentCulture, pattern, values);
    }
