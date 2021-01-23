    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddExceptionHandlingPolicies(options =>
        {
            options.For<InitializationException>().Rethrow();
                
            options.For<SomeTransientException>().Retry(ro => ro.MaxRetryCount = 2).NextPolicy();
                
            options.For<SomeBadRequestException>()
            .Response(e => 400)
                .Headers((h, e) => h["X-MyCustomHeader"] = e.Message)
				.WithBody((req,sw, exception) =>
                    {
                        byte[] array = Encoding.UTF8.GetBytes(exception.ToString());
                        return sw.WriteAsync(array, 0, array.Length);
                    })
            .NextPolicy();
            // Ensure that all exception types are handled by adding handler for generic exception at the end.
            options.For<Exception>()
            .Log(lo =>
                {
                    lo.EventIdFactory = (c, e) => new EventId(123, "UnhandlerException");
                    lo.Category = (context, exception) => "MyCategory";
                })
            .Response(null, ResponseAlreadyStartedBehaviour.GoToNextHandler)
                .ClearCacheHeaders()
                .WithObjectResult((r, e) => new { msg = e.Message, path = r.Path })
            .Handled();
        });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseExceptionHandlingPolicies();
        app.UseMvc();
    }
