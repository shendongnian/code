	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				  name: "BaseCategoryAndSubCategoryId",
				  url: "{controller}/{action}/BaseCategoryId-{BaseCategoryId}/SubCategoryId-{SubCategoryId}",
				  defaults: new { controller = "Home", action = "AddAndManageProperties" }
			);
			
			routes.MapRoute(
				name: "BaseCategoryIdOnly",
				url: "{controller}/{action}/BaseCategoryId-{BaseCategoryId}",
				defaults: new { controller = "Home", action = "AddAndManageProperties" }
			);
			
			routes.MapRoute(
				name: "SubCategoryIdOnly",
				url: "{controller}/{action}/SubCategoryId-{SubCategoryId}",
				defaults: new { controller = "Home", action = "AddAndManageProperties" }
			);
			 
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
