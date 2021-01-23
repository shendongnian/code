    container.RegisterWebApiRequest<ISecureDataFormat<AuthenticationTicket>,
        SecureDataFormat<AuthenticationTicket>>();
    container.RegisterWebApiRequest<ITextEncoder, Base64UrlTextEncoder>();
    container.RegisterWebApiRequest<IDataSerializer<AuthenticationTicket>, TicketSerializer>();
    container.RegisterWebApiRequest<IDataProtector>(
        () => new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider()
            .Create("ASP.NET Identity"));
