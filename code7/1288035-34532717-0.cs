    public ActionResult Index()
    {
     var cache = MemoryCache.Default;
     CacheItemPolicy policy = new CacheItemPolicy();
     policy.AbsoluteExpiration = DateTime.Now.AddDays(1);
    
     var products = new List<string> { "iPhone","MacBookPro","Beer"}
    
     var cacheKey="products;
     cache.Set(cacheKey, products, policy);
    
     return View();
    }
    public ActionResult List()
    {
       //Check item exist in the cache, Read if exists
       var cacheKey="products";
       var test= cache.Get(cacheKey);
       return View();
    }
