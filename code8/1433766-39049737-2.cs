    public override void OnAuthorization(HttpActionContext actionContext)
    {
        if(Throw403)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
