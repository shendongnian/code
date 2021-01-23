     [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
     public class FeatureAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
     {
      public override void OnAuthorization (AuthorizationContext filterContext,bool flagvalue)
       {
            if (filterContext.RouteData.Values["flag"]== false) // I want to check here
            {
                string redirectURL = @"~/Employer/FeatureDenied";// Redirect to Action Method 
                filterContext.Result = new RedirectResult(redirectURL);
            }
        }
     }
