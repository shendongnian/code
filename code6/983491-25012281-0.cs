     [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
     public class FeatureAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
     {
      public override void OnAuthorization (AuthorizationContext filterContext,bool flagvalue)
       {
            if (flagvalue== false) // I want to check here
            {
                string redirectURL = @"~/Employer/FeatureDenied";// Redirect to Action Method 
                filterContext.Result = new RedirectResult(redirectURL);
                filterContext.RouteData.Values.Add("flag", "// flag value //");  <------You can store flag inside RoutData.
            }
        }
     }
