    using System;
    
    namespace MyLib
    {
    #if NETFX
        using HttpContext = System.Web.HttpContext;
    #elif NETCORE
        using HttpContext = Microsoft.AspNetCore.Http.HttpContext;
    #endif
        public class MyClass
        {
            public string GetUserAgent(HttpContext ctx)
            {
                return ctx.Request.Headers["User-Agent"];
            }
            public void WriteToResponse(HttpContext ctx, string text)
            {
    #if NETFX
                ctx.Response.Output.Write(text);
    #elif NETCORE
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                ctx.Response.Body.Write(bytes, 0, bytes.Length);
    #endif
            }
        }
    }
