	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	public class CachedRoute<TPrimaryKey> : RouteBase
	{
		private readonly string cacheKey;
		private readonly string controller;
		private readonly string action;
		private readonly ICachedRouteDataProvider<TPrimaryKey> dataProvider;
		private readonly IRouteHandler handler;
		private object synclock = new object();
		public CachedRoute(string controller, string action, ICachedRouteDataProvider<TPrimaryKey> dataProvider)
			: this(controller, action, typeof(CachedRoute<TPrimaryKey>).Name + "_GetMap_" + controller + "_" + action, dataProvider, new MvcRouteHandler())
		{
		}
		public CachedRoute(string controller, string action, string cacheKey, ICachedRouteDataProvider<TPrimaryKey> dataProvider, IRouteHandler handler)
		{
			if (string.IsNullOrWhiteSpace(controller))
				throw new ArgumentNullException("controller");
			if (string.IsNullOrWhiteSpace(action))
				throw new ArgumentNullException("action");
			if (string.IsNullOrWhiteSpace(cacheKey))
				throw new ArgumentNullException("cacheKey");
			if (dataProvider == null)
				throw new ArgumentNullException("dataProvider");
			if (handler == null)
				throw new ArgumentNullException("handler");
			this.controller = controller;
			this.action = action;
			this.cacheKey = cacheKey;
			this.dataProvider = dataProvider;
			this.handler = handler;
			// Set Defaults
			CacheTimeoutInSeconds = 900;
		}
		public int CacheTimeoutInSeconds { get; set; }
		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			string requestPath = httpContext.Request.Path;
			if (!string.IsNullOrEmpty(requestPath))
			{
				// Trim the leading and trailing slash
				requestPath = requestPath.Trim('/'); 
			}
			TPrimaryKey id;
			//If this returns false, that means the URI did not match
			if (!this.GetMap(httpContext).TryGetValue(requestPath, out id))
			{
				return null;
			}
			var result = new RouteData(this, new MvcRouteHandler());
			result.Values["controller"] = this.controller;
			result.Values["action"] = this.action;
			result.Values["id"] = id;
			return result;
		}
		public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
		{
			TPrimaryKey id;
			object idObj;
			object controller;
			object action;
			if (!values.TryGetValue("id", out idObj))
			{
				return null;
			}
			id = SafeConvert<TPrimaryKey>(idObj);
			values.TryGetValue("controller", out controller);
			values.TryGetValue("action", out action);
			// The logic here should be the inverse of the logic in 
			// GetRouteData(). So, we match the same controller, action, and id.
			// If we had additional route values there, we would take them all 
			// into consideration during this step.
			if (action.Equals(this.action) && controller.Equals(this.controller))
			{
				// The 'OrDefault' case returns the default value of the type you're 
				// iterating over. For value types, it will be a new instance of that type. 
				// Since KeyValuePair<TKey, TValue> is a value type (i.e. a struct), 
				// the 'OrDefault' case will not result in a null-reference exception. 
				// Since TKey here is string, the .Key of that new instance will be null.
				var virtualPath = GetMap(requestContext.HttpContext).FirstOrDefault(x => x.Value.Equals(id)).Key;
				if (!string.IsNullOrEmpty(virtualPath))
				{
					return new VirtualPathData(this, virtualPath);
				}
			}
			return null;
		}
		private IDictionary<string, TPrimaryKey> GetMap(HttpContextBase httpContext)
		{
			IDictionary<string, TPrimaryKey> map;
			var cache = httpContext.Cache;
			map = cache[this.cacheKey] as IDictionary<string, TPrimaryKey>;
			if (map == null)
			{
				lock (synclock)
				{
					map = cache[this.cacheKey] as IDictionary<string, TPrimaryKey>;
					if (map == null)
					{
						map = this.dataProvider.GetVirtualPathToIdMap(httpContext);
						cache[this.cacheKey] = map;
					}
				}
			}
			return map;
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
ICachedRouteDataProvider<TPrimaryKey>
