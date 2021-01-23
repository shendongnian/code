    EFDbContext db = new EFDbContext();
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        //handle base authorization logic
        base.OnAuthorization(filterContext);     
        
        //if user is not authorized (by base rules) simply return because redirect was set in 'base.OnAuthorization' call.    
        if (this.AuthorizeCore(filterContext.HttpContext) == false)
        {
           return;
        }
        
        //Here comes your custom redirect logic:
        if (!db.Subscriptions.Any(s => s.AdminSerial.Equals(db.Serials.Any())))
        {
            filterContext.Result = your redirect url goes here;
        }                  
      }
