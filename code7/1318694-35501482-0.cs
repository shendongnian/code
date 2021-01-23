    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Web.Mvc;
    
    namespace Cludo.App.Utility
    {
        /// <summary>
        /// Used to log requests to server
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class LogActionRequestsAttribute : ActionFilterAttribute
        {
            private readonly ILog _logger;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="logger"></param>
            public LogActionRequestsAttribute(ILog logger)
            {
                this._logger = logger;
            }
    
            public static Stopwatch GetTimer(HttpRequestMessage request)
            {
                const string key = "__timer__";
                if (request.Properties.ContainsKey(key))
                {
                    return (Stopwatch)request.Properties[key];
                }
    
                var result = new Stopwatch();
                request.Properties[key] = result;
                return result;
            }
            
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                
                var timer = GetTimer(actionContext.Request);
                timer.Start();
                base.OnActionExecuting(actionContext);
            }
    
    
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                base.OnActionExecuted(actionExecutedContext);
                var timer = GetTimer(actionExecutedContext.Request);
                timer.Stop();
                var totalTime = timer.ElapsedMilliseconds;            
            }
        }
    }
