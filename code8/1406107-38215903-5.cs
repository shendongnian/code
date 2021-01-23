    using System.Web.Helpers;
    using System.Security.Claims;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // ... your other startup/registration code ...
    
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }
    }
