    container.RegisterType(typeof(ISecureDataFormat<>), typeof(SecureDataFormat<>));
    container.RegisterType<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>();
    container.RegisterType<ISecureDataFormat<AuthenticationTicket>, TicketDataFormat>();
    container.RegisterType<IDataSerializer<AuthenticationTicket>, TicketSerializer>();
    container.RegisterType<IDataProtector>(
        new InjectionFactory(c => new DpapiDataProtectionProvider().Create("ASP.NET Identity")));
