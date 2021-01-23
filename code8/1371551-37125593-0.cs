    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext) {
            
            //For demo purpose only. In real life your custom principal might be retrieved via different source. i.e context/request etc.
            filterContext.Principal = new MyCustomPrincipal(filterContext.HttpContext.User.Identity, new []{"Admin"}, "Red");
        }
        
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
            var color = ((MyCustomPrincipal) filterContext.HttpContext.User).HairColor;
            var user = filterContext.HttpContext.User;
            
            if (!user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
