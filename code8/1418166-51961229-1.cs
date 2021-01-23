        private readonly IMemoryCache _memoryCacheService;
    public yourcontroller(IMemoryCache memoryCacheService)
    {
                _memoryCacheService = memoryCacheService;
            }
        
        public IHttpActionResult AddCacheItem(string cacheKey)
                {
                    _memoryCacheService.Set(cacheKey, DateTime.Now.Ticks );
                    var temp = _memoryCacheService.Get(cacheKey);
                    return Ok(temp);
                }
