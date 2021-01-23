    var container = new Container();
    container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
    container.RegisterConditional(typeof(ICredentialProvider),
        Lifestyle.Scoped.CreateRegistration(() => new FakedCredentialProvider(user, pwd), 
            container),
        c => c.Consumer.Target.Name.ToLower().Contains("sharepoint"));
