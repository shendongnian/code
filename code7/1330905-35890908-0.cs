    public override void OnAuthorization(HttpActionContext actionContext) {
        var attribute = actionContext.ActionDescriptor.GetCustomAttributes<SkipPasswordExpirationAttribute >(true).FirstOrDefault();
        if (attribute != null)
            return;
        //You have access to the Request and Response as well.
        var request = actionContext.Request;
        var response = actionContext.Response;
        //...Once you decide the password has expired, 
        //update the response with an appropriate status code 
        //and response message that would make sense 
        //to the client that made the request
        response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
        response.ReasonPhrase = "Password expired";
        base.OnAuthorization(actionContext);
    }
