    public class Foo : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var cookie = actionContext.Request.Headers.GetCookies("Bar").FirstOrDefault();
        }
    }
