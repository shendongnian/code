    protected void Application_Error(object sender, EventArgs e)
    {
        var httpContext = ((MvcApplication)sender).Context;
        var currentController = " ";
        var currentAction = " ";
        var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
    
        if (currentRouteData != null)
        {
            if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
            {
                currentController = currentRouteData.Values["controller"].ToString();
            }
    
            if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
            {
                currentAction = currentRouteData.Values["action"].ToString();
            }
        }
    
        var ex = Server.GetLastError();
        var controllerFactory = Setup.GetControllerFactory();
        var controller = (Controller)controllerFactory.CreateController(httpContext.Request.RequestContext, "Error");
        var routeData = new RouteData();
        var action = "Index";
    
        if (ex is HttpException)
        {
            var httpEx = ex as HttpException;
    
            switch (httpEx.GetHttpCode())
            {
                case 401:
                    action = "Unauthorized";
                    break;
                case 403:
                    action = "Forbidden";
                    break;
                case 404:
                    action = "NotFound";
                    break;
                default:
                    break;
            }
        }
    
        httpContext.ClearError();
        httpContext.Response.Clear();
        httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
        httpContext.Response.TrySkipIisCustomErrors = true;
    
        routeData.Values["controller"] = "Error";
        routeData.Values["action"] = action;
    
        controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
        ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
    }
