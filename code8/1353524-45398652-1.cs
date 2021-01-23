    services.AddMvc();
    // Add application services.
    services.AddTransient<IEmailSender, AuthMessageSender>();
    services.AddTransient<ISmsSender, AuthMessageSender>();
        
    services.RegisterQueryHandler<FindThingByIdQueryHandler, FindThingByIdQuery, Thing>();
