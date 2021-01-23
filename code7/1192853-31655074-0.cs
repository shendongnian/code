    namespace MyApplication.Filters
    {
        using System;
        using System.Net;
        using System.Net.Http;
        using System.Web.Http.Filters;
        public class CustomHeadersFilterAttribute : ExceptionFilterAttribute 
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                context.Response.Content.Headers.Add("X-CustomHeader", "whatever...");
            }
        }
}
