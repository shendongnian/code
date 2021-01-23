    public static void NoPermissions(ActionExecutingContext filterContext)
    {
        string actionName = filterContext.ActionDescriptor.ActionName;
        string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        string querystrings = "";
    
        foreach (var item in filterContext.ActionParameters)
        {
            if (item.Value != null)
                querystrings += "$" + item.Key + "=" + item.Value.ToString();
        }
    
        filterContext.Result = new RedirectResult("~/Error/NoPermissions?actionValue=" + actionName + "&controllerValue=" + controllerName + (querystrings != "" ? "&routeValues=" + querystrings : ""));
    }
