      private static void FederatedAuthentication_FederationConfigurationCreated(object sender, FederationConfigurationCreatedEventArgs e)
    {
        //from appsettings...
        const string allowedAudience = "http://audience1/user/get";
        const string rpRealm = "http://audience1/";
        const string domain = "";
        const bool requireSsl = false;
        const string issuer = "http://sts/token/create;
        const string certThumbprint = "mythumbprint";
        const string authCookieName = "StsAuth";
        var federationConfiguration = new FederationConfiguration();
                                 federationConfiguration.IdentityConfiguration.AudienceRestriction.AllowedAudienceUris.Add(new Uri(allowedAudience));
        var issuingAuthority = new IssuingAuthority(internalSts);
        issuingAuthority.Thumbprints.Add(certThumbprint);
        issuingAuthority.Issuers.Add(internalSts);
        var issuingAuthorities = new List<IssuingAuthority> {issuingAuthority};
        var validatingIssuerNameRegistry = new ValidatingIssuerNameRegistry {IssuingAuthorities = issuingAuthorities};
        federationConfiguration.IdentityConfiguration.IssuerNameRegistry = validatingIssuerNameRegistry;
        federationConfiguration.IdentityConfiguration.CertificateValidationMode = X509CertificateValidationMode.None;
        var chunkedCookieHandler = new ChunkedCookieHandler {RequireSsl = false, Name = authCookieName, Domain = domain, PersistentSessionLifetime = new TimeSpan(0, 0, 30, 0)};
        federationConfiguration.CookieHandler = chunkedCookieHandler;
        federationConfiguration.WsFederationConfiguration.Issuer = issuer;
        federationConfiguration.WsFederationConfiguration.Realm = rpRealm;
        federationConfiguration.WsFederationConfiguration.RequireHttps = requireSsl;
        e.FederationConfiguration = federationConfiguration;
