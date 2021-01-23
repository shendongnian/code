    using Ninject;
    public class TenantContextFactoryProvider : Provider<DbContext>
    {
        protected override DbContext CreateInstance(IContext context)
        {
            var tenant = context.Kernel.Get<ITenant>();
            return new DbContext(tenant.ConnectionString);
        }
    }
