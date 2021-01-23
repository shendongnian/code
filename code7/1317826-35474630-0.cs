    public static void Register(HttpConfiguration config)
    {
        //...
        var converter = new Newtonsoft.Json.Converters.IsoDateTimeConverter 
                                         {DateTimeFormat="yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffK"};
        config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(converter);
        // ...
    }
