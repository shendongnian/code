    public class HomeController : Controller
    {
        IMemoryCache memoryCache;
        public HomeController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {   
            var existingBadUsers = new List<int>();
            var cacheKey = "BadUsers";
            List<int> badUserIds = new List<int> { 5, 7, 8, 34 };
            if(memoryCache.TryGetValue(cacheKey, out existingBadUsers))
            {
                var cachedUserIds = existingBadUsers;
            }
            else
            {
                memoryCache.Set(cacheKey, badUserIds);
            }
            return View();
        }
    } 
