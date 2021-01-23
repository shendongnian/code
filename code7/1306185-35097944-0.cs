	public class MyRoute : RouteBase
	{
		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			RouteData result = null;
			// Trim the leading slash
			var path = httpContext.Request.Path.Substring(1);
			if (path.StartsWith("abcd"))
			{
				// Return the item controller
				result = new RouteData(this, new MvcRouteHandler());
				result.Values["controller"] = "Item";
				result.Values["action"] = "View";
				result.Values["id"] = 123;
			}
			
			// TODO: Add other conditions and where to route to here
			
			// IMPORTANT: Always return null if there is no match.
			// This tells .NET routing to check the next route that is registered.
			return result;
		}
		
		public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
		{
			VirtualPathData result = null;
			var controller = Convert.ToString(values["controller"]);
			var action = Convert.ToString(values["action"]);
			var id = Convert.ToString(values["id"]);
			
			if ("Item".Equals(controller) && "View".Equals(action))
			{
				return "abcd?id=" + id;
			}
			// IMPORTANT: Always return null if there is no match.
			// This tells .NET routing to check the next route that is registered.
			return result;
		}
	}
