    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {       
        var viewData = filterContext.Controller.ViewData;
        var view = filterContext.Result as ViewResultBase;
        if (view != null)
        {
            string viewName = view.ViewName;
            // If we did not explicitly specify the view name in View() method,
            // it will be same as the action name. So let's get that.
            if (String.IsNullOrEmpty(viewName))
            {
                viewName = filterContext.ActionDescriptor.ActionName;
            }
            // Do something with the viewName now
    
        }
    }
