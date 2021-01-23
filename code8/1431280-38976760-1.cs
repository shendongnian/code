    var dictionary = new Dictionary<string, ICommunicationClient>();
    foreach (var supportedTenant in supportedTenants) {
        dictionary.Add(supportedTenant, new CommunicationClient(
            new Uri(configuration.AppSettings["communication_api." + supportedTenant]),
            new TenantClientConfiguration(supportedTenant)));
    }
    container.RegisterSingleton<ICommunicationClient>(
        new TenantCommunicationClientComposite(
            new AspNetTenantContext(),
            dictionary));
