    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Framework.Internal;
    
    namespace ActionFilterWebApp.Filters
    {
        public class ThirdPartyServiceActionFilter : ActionFilterAttribute
        {
            public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var routeKey = "myName";
                var routeDataValues = context.RouteData.Values;
                var allowActionInvoke = false;
    
                if (routeDataValues.ContainsKey(routeKey))
                {
                    var routeValue = routeDataValues[routeKey];
                    //allowActionInvoke = ThirdPartyService.Check(routeValue);
                }
    
                if (!allowActionInvoke)
                {
                    //if you setting up Result property - action doesn't invoke
                    context.Result = new BadRequestResult();
                }
    
                return base.OnActionExecutionAsync(context, next);
            }
        }
    }
