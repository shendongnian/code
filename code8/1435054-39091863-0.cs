    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Primitives;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ihq.moth.common.Filters
    {
        public class ApiInjectFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)                
            {
                ///This Code is used to setup json data in a the ViewData Dictionary used by the client side script API, like knowing who the current user is, if they are authenticated, what permissions they have etc (of course the permissions are only used for cosmetic nice haves, permissions are double checked server side).
                var isAuthenticated = context.HttpContext.User != null && context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated;
                var initData = new
                {
                    isAuthenticated = isAuthenticated
                    //TODO Add User Later                
                };
                
                var json = JsonConvert.SerializeObject(initData);
                var controller = context.Controller as Controller;
    
                controller.ViewData["APP_API_INIT_JS"] = json;
            }
    
            public void OnActionExecuting(ActionExecutingContext context)
            {
                
            }
        }
    }
