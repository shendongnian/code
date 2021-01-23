    public class ApplicationStartup : ApplicationEventHandler
    	{
    		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    		{
    			//Custom route
    			RouteTable.Routes.MapRoute(
    				"Ads",
    				"Ads/{action}/{id}",
    				new
    				{
    					controller = "Ads",
    					action = "Index",
    					id = UrlParameter.Optional
    				});
    		}
    	}
