    services.AddMvc();
    services.AddScoped<IUrlHelper>(x =>
    {
       var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
       var factory = x.GetRequiredService<IUrlHelperFactory>();
       return factory.GetUrlHelper(actionContext);
    });
