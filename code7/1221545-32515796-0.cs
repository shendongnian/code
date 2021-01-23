    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    
    namespace StackOverflow.Controllers
    {
        public static class ControllersExtensions
        {
            public static ActionResult Index(this HomeController controller, string ViewName)
            {
                string controllerName = controller.GetType().Name.Replace("Controller", "");
                RouteValueDictionary route = new RouteValueDictionary(new
                {
                    action = ViewName,
                    controller = controllerName
                });
    
                RedirectToRouteResult ret = new RedirectToRouteResult(route);
                
                return ret;
            }
        }
    }
