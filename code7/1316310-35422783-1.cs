    protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool isAuthorized = base.IsAuthorized(actionContext);
            bool isRequestHeaderOk = false;
            return isAuthorized && isRequestHeaderOk;
        }
 
