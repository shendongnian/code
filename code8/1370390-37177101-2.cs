    container.Register<ISecureDataFormat<AuthenticationTicket>,
        SecureDataFormat<AuthenticationTicket>>(Lifestyle.Scoped);
    container.Register<ITextEncoder, Base64UrlTextEncoder>(Lifestyle.Scoped);
    container.Register<IDataSerializer<AuthenticationTicket>, TicketSerializer>(
        Lifestyle.Scoped);
    container.Register<IDataProtector>(
        () => new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider()
            .Create("ASP.NET Identity"),
        Lifestyle.Scoped);
