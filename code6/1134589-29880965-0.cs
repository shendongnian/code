    // in MyHandleErrorAttribute, globally configured
    public override void OnException(ExceptionContext filterContext)
    {
        Debug.Print("HandleErrorAttribute.OnException 1");
        base.OnException(filterContext);
        Debug.Print("HandleErrorAttribute.OnException 2");
    }
    ...
    // in HomeController
    protected override void OnException(ExceptionContext filterContext)
    {
        Debug.Print("Controller OnException 1");
        base.OnException(filterContext);
        Debug.Print("Controller OnException 2");
    }
