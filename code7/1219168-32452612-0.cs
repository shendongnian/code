     public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            CacheTransactionHandler transactionHandler = new CacheTransactionHandler(new InMemoryCache());
            this.AddInterceptor(transactionHandler);
            Loaded += (sender, args) =>
           {
               args.ReplaceService<DbProviderServices>((s, _) => new CachingProviderServices(s, transactionHandler));
           };
        }
    }
