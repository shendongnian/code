    public class MemoryCacheService : MemoryCache
        {
            public MemoryCacheService(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
            {
            }
        }
