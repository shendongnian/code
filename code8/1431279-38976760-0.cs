    sealed class TenantCommunicationClientComposite : ICommunicationClient
    {
        private readonly ITenantContext tenantContext;
        private readonly Dictionary<string, ICommunicationClient> clients;
    
        public TenantCommunicationClientComposite(ITenantContext tenantContext,
            Dictionary<string, ICommunicationClient> clients) {
            this.tenantContext = tenantContext;
            this.clients = clients;
        }
    
        object ICommunicationClient.ClientMethod(object parameter) =>
            this.clients[this.tenantContext.CurrentTenantName].ClientMethod(parameter);
    }
