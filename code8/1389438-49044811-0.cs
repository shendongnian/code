    services.ConfigureSwaggerGen(options =>
    {
        options.SingleApiVersion(new Info
        {
            Version = "v1",
            Title = "My API",
            Description = "API Description"
        });
        options.DescribeAllEnumsAsStrings();
        var xmlDocFile = Path.Combine(AppContext.BaseDirectory, $"{_hostingEnv.ApplicationName}.xml");
        if (File.Exists(xmlDocFile))
        {
            var comments = new XPathDocument(xmlDocFile);
            options.OperationFilter<XmlCommentsOperationFilter>(comments);
            options.ModelFilter<XmlCommentsModelFilter>(comments);
        }
    });
