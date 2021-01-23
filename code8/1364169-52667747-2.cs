    internal sealed class SeedService : ISeedService
    {
        private readonly InitializeContext _identityContext;
        public SeedService(InitializeContext identityContext)
        {
            _identityContext = identityContext;
        }
        public async Task MigrateAsync()
        {
            await _identityContext.Database.MigrateAsync();
        }
        public async Task SeedAsync()
        {
            if (_identityContext.AllMigrationsApplied())
            {
                var strategy = _identityContext.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await _identityContext.Database.BeginTransactionAsync())
                    {
                        // seed data if necessary
                        transaction.Commit();
                    }
                });
            }
        }
    }
