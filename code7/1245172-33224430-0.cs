    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        var response = actionExecutedContext.Response;
        var request = actionExecutedContext.Request;
        var currentCookie = request.Headers.GetCookies("yourCookieName").FirstOrDefault();
        if (currentCookie != null)
        {
            var cookie = new CookieHeaderValue("yourCookieName", "")
            {
                Expires = DateTimeOffset.Now.AddDays(-1),
                Domain = currentCookie.Domain,
                Path = currentCookie.Path
            };
            response.Headers.AddCookies(new[] { cookie });
        }
        base.OnActionExecuted(actionExecutedContext);
    }
