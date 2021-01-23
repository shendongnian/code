	public static class CacheWrapper
    {
        private static List<string> _keys = new List<string>();
        public static List<string> Keys
        {
            get { lock(_keys) { return _keys.ToList(); } }
        }
		
		public static T Fetch<T>(string key, Func<T> dlgt, bool refresh = false) where T : class
		{
			var result = HttpRuntime.Cache.Get(key) as T;
			
			if(result != null && !refresh) return result;
			
			lock(HttpRuntime.Cache)
			{
				lock(_keys)
				{
					_keys.Add(key);
				}
				
				result = dlgt();
				HttpRuntime.Cache.Add(key, result, /* some other params */);
			}
			
			return result;
		}
    }
