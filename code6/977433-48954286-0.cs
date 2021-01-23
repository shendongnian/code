    [Common.PortalSecurity.Login(Order=1)]
    [Common.PortalSecurity.UserRole(Order=2)]  
    public HttpResponseMessage GetAll(string sessionToken)
    {
        return new HttpResponseMessage();
    }
