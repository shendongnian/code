    private string GetRoute(string className, string methodName)
    {
    	var routes = RouteTable.Routes.ToList().OfType<Route>();
    	foreach (var route in routes)
    	{
    		if (route.Defaults != null)
    		{
    			var controller = route.Defaults.FirstOrDefault(d => d.Key == "controller");
    			var action = route.Defaults.FirstOrDefault(d => d.Key == "action");
    
    			if (controller.Value != null && controller.Value.ToString() == className && action.Value != null && action.Value.ToString() == methodName)
    			{
    				return route.Url;
    			}
    		}
    	}
    
    	return null;
    }
