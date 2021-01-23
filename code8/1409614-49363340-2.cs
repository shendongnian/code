    public class DefaultRegistry: Registry
    {
        public static IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(HttpRuntime.AppDomainAppPath)
            .AddJsonFile("appsettings.json")
            .Build();
        public DefaultRegistry()
        {
            For<IConfiguration>().Use(() => Configuration);  
            
    #if DEBUG && DISABLE_CACHE <-- compiler directives
            For<IMemoryCache>().Use(
                () => new MemoryCacheFake()
            ).Singleton();
    #else
            var memoryCacheOptions = new MemoryCacheOptions();
            For<IMemoryCache>().Use(
                () => new MemoryCache(Options.Create(memoryCacheOptions))
            ).Singleton();
    #endif
            For<SKiNDbContext>().Use(() => new SKiNDbContextFactory().CreateDbContext(Configuration));
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            });
        }
    }
    public class MemoryCacheFake : IMemoryCache
    {
        public ICacheEntry CreateEntry(object key)
        {
            return new CacheEntryFake { Key = key };
        }
        public void Dispose()
        {
        }
        public void Remove(object key)
        {
        }
        public bool TryGetValue(object key, out object value)
        {
            value = null;
            return false;
        }
    }
    public class CacheEntryFake : ICacheEntry
    {
        public object Key {get; set;}
        public object Value { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
        public IList<IChangeToken> ExpirationTokens { get; set; }
        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks { get; set; }
        public CacheItemPriority Priority { get; set; }
        public long? Size { get; set; }
        public void Dispose()
        {
        }
    }
