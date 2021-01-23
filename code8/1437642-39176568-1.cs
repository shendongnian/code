    public class SqlStringLocalizerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public SqlStringLocalizerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void SomeMethod()
        {
            using (var serviceScope = _serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var tenant = serviceScope.ServiceProvider.GetService<AppTenant>();
                // do something with tenant...
            }
        }
    }
