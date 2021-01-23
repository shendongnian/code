    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {            
        }
    
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {            
            if (filterContext.HttpContext.Session["UserId"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
