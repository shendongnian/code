    using System.Web;
    
    namespace WebGridTest
    {
    	public static class ExtensionMethods
    	{
    		public static IHtmlString AddRouteValuesToWebGridHeaders(this IHtmlString grid, string routeValues)
    		{
    			var regularString = grid.ToString();
    			regularString = regularString.Replace("?sort=", "?" + routeValues + "&sort=");
    
    			HtmlString htmlString = new HtmlString(regularString);
    
    			return htmlString;
    		}
    	}
    }
