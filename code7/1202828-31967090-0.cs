    public override void OnActionExecuted( ActionExecutedContext filterContext )
    {
        var result   = filterContext.Result as ViewResult;
        var IsMobile = filterContext.Controller.ViewBag.IsMobile;
        var view     = filterContext.ActionDescriptor.ActionName;
        if( result == null ) return;
        string viewName;
        string masterName;
        bool hasLayout = filterContext.Controller.ViewBag.HasLayout ?? true;
        if( IsMobile )
        {
            viewName   = view + ".Mobile";
            masterName = hasLayout ? "_Layout.Mobile" : null;
            //Check if new view exists
            var viewResult = ViewEngines.Engines.FindView( filterContext.Controller.ControllerContext, viewName, null );
            if( viewResult.View == null )
            {
                viewName = view;
            }
        }
        else
        {
            viewName   = view;
            masterName = hasLayout ? "_Layout" : null;
        }
        result.ViewName = viewName;
        result.MasterName = masterName;
    }
