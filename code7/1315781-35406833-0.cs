    class PrintersCache
    {
        private const string CacheName = "MyCacheName";        
        private const string AuditPrinterKey = "AuditPrinterKey";
        private static readonly MemoryCache memoryCache = new MemoryCache(CacheName);
        private const int CacheExpirationInMinutes = 20;
        
        public static List<AuditPrinter> GetAuditPrinterCache()
        {
            // Create a lazy object to retrieve the data when the cache has expired
            var newLazyValue = new Lazy<List<AuditPrinter>>(() =>
            {
                // You should not keep an instance of your db context without disposing it. Also The instantiation of a db context is cheap.
                using (var db = new AuditprinterDBEntities1())
                {
                    return db.AuditPrinter
                        .Include(a => a.Pc)
                        .Include(a => a.PrintersConfig)
                        .Include(a => a.Users).ToList();
                }
            });
            // Return the instance of the Lazy object. If the cahce has expired a new instance of the Lazy object is created.
            return
                ((Lazy<List<AuditPrinter>>)
                    memoryCache.AddOrGetExisting(AuditPrinterKey, newLazyValue, new CacheItemPolicy()
                    {
                        // Defines that the cache will expired after 20min
                        AbsoluteExpiration = new DateTimeOffset(
                            DateTime.UtcNow.AddMinutes(CacheExpirationInMinutes))
                    })).Value;
        }
    }
