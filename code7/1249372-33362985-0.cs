    namespace Blah
    {
        using System;
        using System.Web.Mvc;
        using System.Web.Routing;
        
        public class SessionTimeoutRedirectResult : RedirectToRouteResult
        {
            public SessionTimeoutRedirectResult(
                string routeName,
                RouteValueDictionary routeValueDictionary,
                string redirectActionName,
                string redirectControllerName)
                : base(routeName, routeValueDictionary)
            {
                RedirectActionName = redirectActionName;
                RedirectControllerName = redirectControllerName;
            }
            
            public string RedirectActionName { get; private set; }
    
            public string RedirectControllerName { get; private set; }
    
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
    
                RouteValues.Clear();
                RouteValues.Add("action", RedirectActionName);
                RouteValues.Add("controller", RedirectControllerName);
    
                base.ExecuteResult(context);
            }
        }
    }
