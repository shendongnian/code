    container.RegisterConditional<ISessionService,
        Infrastructure.OldLdap.Service.SessionService>(
        c => c.Consumer.ImplementationType.Namespace.Contains("Oldldap"));
    container.RegisterConditional<ISessionService,
        Infrastructure.NewLdap.Service.SessionService>(
        c => c.Consumer.ImplementationType.Namespace.Contains("Newldap"));
