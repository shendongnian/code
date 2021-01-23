    i know the link you are going on and your answer is here now paste the code 
    and put debugger point on Authorize(httpactioncontext actioncontext) it will 
    be used with ApiController as well.
     public class Authorizetest: System.Web.Http.AuthorizeAttribute
    {
        private const string _securityToken = "token"; 
        public override void OnAuthorization(HttpActionContext actionContext)
        {
         
           if(Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);  
        }
        protected override void HandleUnauthorizedRequest(HttpActionContextactionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
        private bool Authorize(HttpActionContext actionContext)
        {         
            try
            {                           
                var context = new HttpContextWrapper(HttpContext.Current);
                HttpRequestBase request = context.Request;              
                string token = request.Params[_securityToken];
                bool xyz = ValidatingTokens.IsTokenValid(token, 
                CommonManager.GetIP(request), request.UserAgent);
                return xyz;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
