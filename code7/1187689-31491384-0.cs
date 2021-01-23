    public class CustomAuth : System.Web.Http.AuthorizeAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                base.OnAuthorization(actionContext);
    
    
                // Check if for your database value in here
            }
        }
