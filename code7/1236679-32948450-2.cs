    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        var rawid = filterContext.Controller.ValueProvider.GetValue("id"); 
        if(!string.IsNullOrEmpty(rawid.AttemptedValue))
        {
            int id = rawid.ConvertTo(typeof(int))           
        }
        // in case that user is unauthorized:
        filterContext.Result = new HttpUnauthorizedResult();
    } 
