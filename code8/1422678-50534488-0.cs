        public void ConfigureServices(IServiceCollection services)
        {
            ...
    #if DEBUG
            services.AddMvc(opts =>
            {
                opts.Filters.Add(new AllowAnonymousFilter());
            });
    #else
            services.AddMvc();
    #endif
        }
