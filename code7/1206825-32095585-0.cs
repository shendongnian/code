    public class login_handler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
         public void ProcessRequest(HttpContext context)
        {
         	context.Session["mySession"]="ABC";
        }
    }
