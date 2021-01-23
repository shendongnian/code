		public class PageSlugMatch : IRouteConstraint
		{
			private readonly MyDbContext MyDbContext = new MyDbContext();
			public bool Match(
				HttpContextBase httpContext,
				Route route,
				string parameterName,
				RouteValueDictionary values,
				RouteDirection routeDirection
			)
			{
				var routeSlug = values.ContainsKey("slug") ? (string)values["slug"] : "";
				bool slugMatch = false;
				if (!string.IsNullOrEmpty(routeSlug))
				{
					slugMatch = MyDbContext.Pages.Where(x => x.Slug == routeSlug).Any();
				}
				return slugMatch;
			}
		}
