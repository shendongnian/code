    using Newtonsoft.Json;
    ...
    public static void Register(HttpConfiguration config)
    {
        var settings = config.Formatters.JSonFormatter.SerializerSettings;
        settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    }
