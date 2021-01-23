    using System;
    using System.Net;
    using System.Web.Mvc;
    namespace MyNamespace.Attributes
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeRedirectAttribute : AuthorizeAttribute
        {
            public string RedirectUrl = "~/Error/Forbidden403";
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
            }
    
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                base.HandleUnauthorizedRequest(filterContext);
    
                var httpContext = filterContext.RequestContext.HttpContext;
                var request = httpContext.Request;
                var response = httpContext.Response;
    
                // If AJAX request, just return appropriate code
                if (request.IsAjaxRequest())
                {
                    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                    else
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.SuppressFormsAuthenticationRedirect = true;
                    response.End();
                }
    
                // Otherwise check if authenticated, and if not redirect to specified url
                if (httpContext.User.Identity.IsAuthenticated)
                {
                    httpContext.Response.Redirect(RedirectUrl);
                }
            }
        }
    }
