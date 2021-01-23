	using Microsoft.Extensions.Caching.Memory;
	public class HomeController
	{
		private readonly IMemoryCache _cache;
		
		public HomeController(IMemoryCache cache)
		{
			if (cache == null)
				throw new ArgumentNullException("cache");
			_cache = cache;
		}
		public IActionResult Index()
		{
			// Get an item from the cache
			string key = "test";
			object value;
			if (_cache.TryGetValue(key, out value))
			{
				// Reload the value here from wherever
				// you need to get it from
                value = "test";
				_cache.Set(key, value);
			}
			// Do something with the value
			return View();
		}
	}
