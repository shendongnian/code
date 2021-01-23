    public class TenantContextFactoryProvider : Provider<DbContext>
    {
        ITenant tenant;
        public TenantContextFactoryProvider(ITenant tenant)
        {
             this.tenant = tenant;
        }
    
        protected override DbContext CreateInstance(IContext context)
        {
            return new DbContext(tenant.ConnectionString);
        }
    }
