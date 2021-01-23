    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //normal as detauls , removed for space 
        // set my variables all over the site
        SiteUtils.strConnection = Configuration.GetConnectionString("DefaultConnection");
        SiteUtils.AppName = Configuration.GetValue<string>("AppName");
    }
