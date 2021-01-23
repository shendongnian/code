    services.AddMvc()
        ...
        .AddNewtonsoftJson(opts =>
        {
            opts.SerializerSettings.Converters.Add(new StringEnumConverter());
        });
    services.AddSwaggerGen(...);
    services.AddSwaggerGenNewtonsoftSupport(); //
