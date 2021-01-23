    var authContext = new AuthenticationContext(AUTHORITY);
    var store = new X509Store(StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly);
    var certs = store
        .Certificates
        .Find(X509FindType.FindByIssuerName, "mvp2015", false);
    var clientCertificate = new ClientAssertionCertificate(CLIENT_ID_WEB, certs[0]);
    var result = authContext
        .AcquireTokenAsync(RESOURCE, clientCertificate)
        .Result;
