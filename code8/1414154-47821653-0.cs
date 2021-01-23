    public class Foo : AuthorizeAttribute
    {
          public override void OnAuthorization(HttpActionContext actionContext)
          {
               var cookies = actionContext.Request.Headers.GetCookies("Bar").FirstOrDefault();
               var cookie = cookies["Bar"];
          }
    }
