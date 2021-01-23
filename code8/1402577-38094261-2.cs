       public void ConfigureServices(IServiceCollection services)
    {
                services.AddSwaggerGen();
                services.ConfigureSwaggerGen(options =>
                {   
                    options.SingleApiVersion(new Info
                    {
                        Version = "v1",
                        Title = "test API",
                        Description = "test api for swagger",
                        TermsOfService = "None",
                       
                    });
                    options.IncludeXmlComments(/* whatever tha path */);
                    options.DescribeAllEnumsAsStrings();
                });
    
        }
