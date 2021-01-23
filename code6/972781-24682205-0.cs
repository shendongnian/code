    protected override void OnException(ExceptionContext filterContext)
    {
        if (filterContext.Exception is HttpAntiForgeryException)
        {
            this.RedirectToAction(
                filterContext.RouteData.Values["action"].ToString(), 
                filterContext.RouteData.Values);
            filterContext.ExceptionHandled = true;
        }
        base.OnException(filterContext);
    }
