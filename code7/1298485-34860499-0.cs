    public class HomeController : Controller
    {
        private IMemoryCache cache;
        public HomeController(IMemoryCache cache)
        {
            this.cache = cache;
        }
