    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        BaseModel model = filterContext.Controller.ViewData.Model as BaseModel;
        if (model != null)
        {
            model.foo = "foo value";
            model.bar = "bar value";
        }
        base.OnActionExecuted(filterContext);
    }
