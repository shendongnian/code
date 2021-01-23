    string TheRequest = HttpContext.Current.Request.Url.AbsolutePath.ToString();
    
    foreach (Route r in System.Web.Routing.RouteTable.Routes)
    {
    	if (("/" + r.Url) == TheRequest)
    	{
    		//the request is in the routes
    	}
    }
