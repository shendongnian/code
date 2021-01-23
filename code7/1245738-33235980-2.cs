    builder.RegisterType<HttpContextSiteNameProvider>()
           .As<ISiteNameProvider>()
           .InstancePerRequest();
    builder.Register(c => 
    {
        String siteName = c.Resolve<ISiteNameProvider>().SiteName;
        if(siteName == "www.domain.com") 
        {
            return c.ResolveNamed<IProvider>("one");
        }
        else 
        {
            return c.ResolveNamed<IProvider>("two");
        }
    })
    .As<IProvider>()
    .InstancePerRequest();
   
