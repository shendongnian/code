    async Task<HttpResponseMessage> IActionFilter.ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
    {
        // Process the request pipeline and get the response (this causes the action to be executed)
        HttpResponseMessage response = await continuation();
        // If the user is authenticated and the token is not present in the request cookies, then it needs to be set
        CustomPrincipal principal = actionContext.ControllerContext.RequestContext.Principal as CustomPrincipal;
        if (principal != null && !actionContext.Request.Headers.GetCookies("MySessionCookie").Any())
        {
            // Set the cookie in the response
            var cookie = new CookieHeaderValue("MySessionCookie", principal.AuthenticationToken) { Path = "/", HttpOnly = true };
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
        }
        return response;
    }
