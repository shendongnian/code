    // would use IAuthenticationFilter in MVC 5
    public class CultureFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // simplified for this example
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de");
        }
    }
