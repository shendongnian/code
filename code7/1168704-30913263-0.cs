    using System.Web.Http;
    
        namespace WebConfig
        {
        	public static class WebApiConfig
        	{
        		public static void Register(HttpConfiguration config)
        		{
        			config.MapHttpAttributeRoutes();
        		}
        	}
        }
