    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
    	base.OnActionExecuting(filterContext);
    
    	//Set TenantByDomain
    	var DnsSafeHost = filterContext.HttpContext.Request.Url.DnsSafeHost;
    	int? TenantByDomain = null;
    	if (db.Tenants.Any(x => x.DnsDomains.Contains(DnsSafeHost)))
    	{
    		TenantByDomain = db.Tenants.First(x => x.DnsDomains.Contains(DnsSafeHost)).Id;
    	}
    	((BaseController)(filterContext.Controller)).TenantByDomain = TenantByDomain;
    	filterContext.Controller.ViewBag.TenantByDomain = TenantByDomain;
    }
