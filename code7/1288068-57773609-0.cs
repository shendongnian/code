    // include in the ReportsController class
    
    protected override UserIdentity GetUserIdentity()
    {
        var identity = base.GetUserIdentity();
        identity.Context = new System.Collections.Concurrent.ConcurrentDictionary<string, object>();
        identity.Context["UrlReferrer"] = System.Web.HttpContext.Current.Request.UrlReferrer;
    
        // Any other available information can be stored in the identity.Context in the same way
    
        return identity;
    }
