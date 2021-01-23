    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        //gets the value of Id parameter
        var id = filterContext.Controller.ValueProvider.GetValue("id"); 
    } 
