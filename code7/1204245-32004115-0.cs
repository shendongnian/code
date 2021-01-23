    class OrganizationServiceFactory: IOrganizationServiceFactory, IDisposable
    {
        private readonly ConcurrentBag<OrganizationServiceProxy> _issuedProxies =
            new ConcurrentBag<OrganizationServiceProxy>(); 
        public IOrganizationService CreateOrganizationService(Guid? userId)
        {
            var serverName = (string)ConfigurationManager.AppSettings["OrganisationUrl"];
            Uri organisationUri = new Uri(string.Format("{0}/XRMServices/2011/Organization.svc", serverName));
            var credentials = new ClientCredentials();
            credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            
            var serviceProxy = new OrganizationServiceProxy(organisationUri, null, credentials, null);
            _issuedProxies.Add(serviceProxy);
            return serviceProxy;
        }
        public void Dispose()
        {
            foreach (var serviceProxy in _issuedProxies)
            {
                serviceProxy.Dispose();
            }
        }
    }
