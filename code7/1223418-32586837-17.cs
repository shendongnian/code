    using Microsoft.AspNet.Routing;
    using Microsoft.Framework.Caching.Memory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
	public class CachedRoute<TPrimaryKey> : IRouter
	{
		private readonly string _controller;
		private readonly string _action;
		private readonly ICachedRouteDataProvider<TPrimaryKey> _dataProvider;
		private readonly IMemoryCache _cache;
		private readonly IRouter _target;
		private readonly string _cacheKey;
		private object _lock = new object();
		public CachedRoute(
			string controller, 
			string action, 
			ICachedRouteDataProvider<TPrimaryKey> dataProvider, 
			IMemoryCache cache, 
			IRouter target)
		{
			if (string.IsNullOrWhiteSpace(controller))
				throw new ArgumentNullException("controller");
			if (string.IsNullOrWhiteSpace(action))
				throw new ArgumentNullException("action");
			if (dataProvider == null)
				throw new ArgumentNullException("dataProvider");
			if (cache == null)
				throw new ArgumentNullException("cache");
			if (target == null)
				throw new ArgumentNullException("target");
			_controller = controller;
			_action = action;
			_dataProvider = dataProvider;
			_cache = cache;
			_target = target;
			// Set Defaults
			CacheTimeoutInSeconds = 900;
			_cacheKey = "__" + this.GetType().Name + "_GetPageList_" + _controller + "_" + _action;
		}
		public int CacheTimeoutInSeconds { get; set; }
		public async Task RouteAsync(RouteContext context)
		{
			var requestPath = context.HttpContext.Request.Path.Value;
			if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
			{
				// Trim the leading slash
				requestPath = requestPath.Substring(1);
			}
			// Get the page id that matches.
			TPrimaryKey id;
			//If this returns false, that means the URI did not match
			if (!GetPageList().TryGetValue(requestPath, out id))
			{
				return;
			}
            //Invoke MVC controller/action
            var routeData = context.RouteData;
            // TODO: You might want to use the page object (from the database) to
            // get both the controller and action, and possibly even an area.
            // Alternatively, you could create a route for each table and hard-code
            // this information.
            routeData.Values["controller"] = _controller;
            routeData.Values["action"] = _action;
            // This will be the primary key of the database row.
            // It might be an integer or a GUID.
            routeData.Values["id"] = id;
            await _target.RouteAsync(context);
		}
		public VirtualPathData GetVirtualPath(VirtualPathContext context)
		{
			VirtualPathData result = null;
			string virtualPath;
			if (TryFindMatch(GetPageList(), context.Values, out virtualPath))
			{
				result = new VirtualPathData(this, virtualPath);
			}
			return result;
		}
		private bool TryFindMatch(IDictionary<string, TPrimaryKey> pages, IDictionary<string, object> values, out string virtualPath)
		{
			virtualPath = string.Empty;
			TPrimaryKey id;
			object idObj;
			object controller;
			object action;
			if (!values.TryGetValue("id", out idObj))
			{
				return false;
			}
			id = SafeConvert<TPrimaryKey>(idObj);
			values.TryGetValue("controller", out controller);
			values.TryGetValue("action", out action);
			// The logic here should be the inverse of the logic in 
			// RouteAsync(). So, we match the same controller, action, and id.
			// If we had additional route values there, we would take them all 
			// into consideration during this step.
			if (action.Equals(_action) && controller.Equals(_controller))
			{
				// The 'OrDefault' case returns the default value of the type you're 
				// iterating over. For value types, it will be a new instance of that type. 
				// Since KeyValuePair<TKey, TValue> is a value type (i.e. a struct), 
				// the 'OrDefault' case will not result in a null-reference exception. 
				// Since TKey here is string, the .Key of that new instance will be null.
				virtualPath = pages.FirstOrDefault(x => x.Value.Equals(id)).Key;
				if (!string.IsNullOrEmpty(virtualPath))
				{
					return true;
				}
			}
			return false;
		}
		private IDictionary<string, TPrimaryKey> GetPageList()
		{
			IDictionary<string, TPrimaryKey> pages;
			if (!_cache.TryGetValue(_cacheKey, out pages))
			{
				// Only allow one thread to poplate the data
				lock (_lock)
				{
					if (!_cache.TryGetValue(_cacheKey, out pages))
					{
						pages = _dataProvider.GetPageToIdMap();
						_cache.Set(_cacheKey, pages,
							new MemoryCacheEntryOptions()
							{
								Priority = CacheItemPriority.NeverRemove,
								AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(this.CacheTimeoutInSeconds)
							});
					}
				}
			}
			return pages;
		}
		private static T SafeConvert<T>(object obj)
		{
			if (typeof(T).Equals(typeof(Guid)))
			{
				if (obj.GetType() == typeof(string))
				{
					return (T)(object)new Guid(obj.ToString());
				}
				return (T)(object)Guid.Empty;
			}
			return (T)Convert.ChangeType(obj, typeof(T));
		}
	}
