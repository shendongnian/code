    builder.RegisterModule<AutofacWebTypesModule>();
    builder.RegisterType<QueryStringUserNameProvider>()
           .As<IUserNameProvider>()
           .InstancePerRequest(); 
    builder.Register((c,p) => {
        var accessService = c.Resolve<IAccessService>();
        var userNameProvider = c.Resolve<IUserNameProvider>(); 
        var access = accessService.GetBySite(userNameProvider.UserName);
        return new JsonWebRequest(access.Site, access.Token);
    }).InstancePerRequest();
