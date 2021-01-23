    public class OnlyLocalRequests : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                filterContext.HttpContext.Response.End();
            }
        }
    }
