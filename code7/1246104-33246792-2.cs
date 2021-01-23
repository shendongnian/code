    public class OnlyLocalRequests : AuthorizeAttribute
    {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (!httpContext.Request.IsLocal)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return false;
                }
                return true;
            }
    }
