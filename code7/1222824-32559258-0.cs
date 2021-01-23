    class NewSessionService : SessionService {
        public NewSessionService(ILdabConfigService s) { ... }
    }
    container.RegisterConditional<ISessionService, SessionService>(
        c => c.Consumer.ImplementationType.Namespace.Contains("Old"));
    container.RegisterConditional<ILdabConfigServices, Old.LdapConfigService>(
        c => c.Consumer.ImplementationType == typeof(SessionService));
    container.RegisterConditional<ISessionService, NewSessionService>(
        c => c.Consumer.ImplementationType.Namespace.Contains("New"));
    container.RegisterConditional<ILdabConfigServices, New.LdapConfigService>(
        c => c.Consumer.ImplementationType == typeof(NewSessionService));
