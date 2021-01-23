    public class MsgTypeHandler : IHandleMessages<MsgType>
    {
        public MsgTypeHandler(ISettingsServiceFactory factory) {...}
    
        public async Task Handle(MsgType message)
        {
            var tenantId = message.TenantId;
            ISettingsService svc = this.factory.Create(tenantId);
    
            // User svc here...
        }
    }
