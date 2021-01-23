CustomAuthorize
    using System.Configuration;
    using System.Web;
    using System.Web.Mvc;
    namespace Namespace.Filters {
        public class CustomAuthorize : AuthorizeAttribute {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
                string issuer = System.Configuration.ConfigurationManager.AppSettings.Get("ida:Issuer");
                // default issuer, use if loading from AppSettings fails.
                if (issuer == null) {
                    issuer = "https://login.windows.net/98297c67-25a1-404d-aab3-673b6096747f/wsfed";
                }
                var reply = ConfigurationManager.AppSettings["reply"];
                reply = HttpUtility.UrlEncode(HttpUtility.UrlEncode(reply));
                var SignInRequest = string.Format(@"{0}?wa=wsignin1.0&wtrealm=https%3a%2f%2f{myapp}%2f&wctx=rm%3d0%26id%3d2fcc67c4-3671-408b-b6fe-0c2cae2763c9%26ru%3d{1}&wct=2014-07-31T01%3a21%3a16Z", issuer, reply);
                filterContext.RequestContext.HttpContext.Response.Redirect(SignInRequest);
            }
        }
    }
