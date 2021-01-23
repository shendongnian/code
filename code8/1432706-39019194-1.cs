       public class PrincipalMemoryCacheAside // : IPrincipalCacheAside
        {
            public const string CacheKeyPrefix = "PrincipalMemoryCacheAsideKey";
    
            public ClaimsPrincipal GetTheClaimsPrincipal(string uniqueIdentifier)
            {
                string cacheKey = this.GetFullCacheKey(uniqueIdentifier);
                ClaimsPrincipal cachedOrFreshPrincipal = GetFromCache<ClaimsPrincipal>(
                    cacheKey, 
                    () =>
                    {
                        ClaimsPrincipal returnPrinc = null;
    
                        /* You would go hit your web service here to populate your object */
                        ClaimsIdentity ci = new GenericIdentity(this.GetType().ToString());
                        ci.AddClaim(new Claim("MyType", "MyValue"));
                        returnPrinc  = new ClaimsPrincipal(ci);
    
                        return returnPrinc;
                    });
    
                return cachedOrFreshPrincipal;
            }
    
            private TEntity GetFromCache<TEntity>(string key, Func<TEntity> valueFactory) where TEntity : class
            {
    
                ObjectCache cache = MemoryCache.Default;
                //// the lazy class provides lazy initializtion which will evaluate the valueFactory expression only if the item does not exist in cache
                var newValue = new Lazy<TEntity>(valueFactory);
                CacheItemPolicy policy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(0, 60, 0), Priority = CacheItemPriority.NotRemovable };
                ////The line below returns existing item or adds the new value if it doesn't exist
                var value = cache.AddOrGetExisting(key, newValue, policy) as Lazy<TEntity>;
                return (value ?? newValue).Value; // Lazy<T> handles the locking itself
            }
    
            private string GetFullCacheKey(string uniqueIdentifier)
            {
                string returnValue = CacheKeyPrefix + uniqueIdentifier;
                return returnValue;
            }
        }
