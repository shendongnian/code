    public static void Register(HttpConfiguration config)
    {
        ...
        config
            .Formatters
            .JsonFormatter
            .SerializerSettings
            .Converters
            .Add(new ContentTypeJsonConverter());
    }
