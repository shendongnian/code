     public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            CacheTransactionHandler transactionHandler = new CacheTransactionHandler(new InMemoryCache());
            this.AddInterceptor(transactionHandler);
            MyCachingPolicy cachingPolicy = new MyCachingPolicy();         
            Loaded += (sender, args) =>
           {
               args.ReplaceService<DbProviderServices>((s, _) => new CachingProviderServices(s, transactionHandler, cachingPolicy));
           };
        }
    }
    internal class MyCachingPolicy : CachingPolicy
    {
        #region Constructor
        internal MyCachingPolicy()
        {
            this.NonCachableTables = new List<string>()
            {
                "AspNetUsers",
                "Resource",
                "Task",
                "Appointment"
            };
        }
        #endregion Constructor
        #region Properties
        private List<string> NonCachableTables { get; set; }
        #endregion Properties
        #region Methods
        #endregion Methods
        protected override bool CanBeCached(ReadOnlyCollection<EntitySetBase> affectedEntitySets, string sql, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return !affectedEntitySets.Select(e => e.Table ?? e.Name).Any(tableName => this.NonCachableTables.Contains(tableName));
        }
        protected override void GetCacheableRows(ReadOnlyCollection<EntitySetBase> affectedEntitySets, out int minCacheableRows, out int maxCacheableRows)
        {
            base.GetCacheableRows(affectedEntitySets, out minCacheableRows, out maxCacheableRows);
        }
        protected override void GetExpirationTimeout(ReadOnlyCollection<EntitySetBase> affectedEntitySets, out TimeSpan slidingExpiration, out DateTimeOffset absoluteExpiration)
        {
            base.GetExpirationTimeout(affectedEntitySets, out slidingExpiration, out absoluteExpiration);
        }
    }
