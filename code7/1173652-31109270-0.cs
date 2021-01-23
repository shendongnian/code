	private void Application_BeginRequest(object sender, EventArgs eventArgs)
	{       
	    if (System.Web.Routing.RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current)) == null)
	    {
	        HttpContext.Current.Response.StatusCode = 404;
	    }
	}
