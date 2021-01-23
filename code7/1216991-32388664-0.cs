    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Custom attribute for handling session timeout
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check if session is supported
            if (ctx.Session != null)
            {
                // check if a new session id was generated
                if (ctx.Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must
                    // have timed out
                    string sessionCookie = ctx.Request.Headers["Cookie"];
                    if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        ctx.Response.Redirect("~/Error/SessionTimeoutVeiw");
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
