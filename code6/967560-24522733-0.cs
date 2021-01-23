    public override void OnAuthorization(HttpActionContext actionContext)
    {
            if (actionContext.Request.Headers.Authorization != null)
            {
                //Check user credentials/token here
                //Get internal user
                IPrincipal principal = new MyOwnCustomPrincipal(internalUser);
                HttpContext.Current.User = principal;
                return;
            }
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
    }
