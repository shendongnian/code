    if (!Request.IsAuthenticated)
        return RedirectToAction("SomethingBroke");
    CasPrincipal cp = User as CasPrincipal;
    ClaimsPrincipal p = new ClaimsPrincipal(cp.Identity);
                   FederatedPassiveSecurityTokenServiceOperations.ProcessRequest(System.Web.HttpContext.Current.Request, p, WIF.TLCSecurityTokenServiceConfiguration.Current.CreateSecurityTokenService(), System.Web.HttpContext.Current.Response);
