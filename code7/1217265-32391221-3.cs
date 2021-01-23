    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
        {
    
            public void OnAuthentication(AuthenticationContext filterContext)
            {
    
                var user= new User (HttpContext.Current.User);
                Thread.CurrentPrincipal = user;
            }
    
      }
