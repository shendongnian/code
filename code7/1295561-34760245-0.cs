    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        var value = filterContext.Controller.ValueProvider.GetValue("anyproperty");
        ...
    }
