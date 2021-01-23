    public class CertificateAuthorizationAttribute : AuthorizeAttribute
    {      
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // your custom logic here
            base.OnAuthorization(actionContext);
        }
    }
