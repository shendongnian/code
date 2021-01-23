    services.AddSwaggerGen(options =>
    {
    options.SwaggerDoc(version,
        new Info
        {
            Title = name,
            Version = version
        }
    );
    options.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));
    options.TagActionsBy(api => api.GroupName);
    });
