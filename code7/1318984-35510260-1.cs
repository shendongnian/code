    using Microsoft.AspNet.Builder;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Http;
    using System.IO;
    using System.Text;
    using System.Net;
    
    namespace App04SimpleMiddleware
    {
        public class SimpleMiddleware
        {
            private readonly RequestDelegate _next;
            public SimpleMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                if (context.Request.QueryString.ToString().Contains("simple"))
                {
                    await ReturnIndexPage(context);
                    return;
                }
                await _next.Invoke(context);
            }
    
            private static async Task ReturnIndexPage(HttpContext context)
            {
                var file = new FileInfo(@"wwwroot\response.html");
                byte[] buffer;
                if (file.Exists)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "text/html";
    
                    buffer = File.ReadAllBytes(file.FullName);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Response.ContentType = "text/plain";
    
                    buffer = Encoding.UTF8.GetBytes("Unable to find the requested file");
                }
    
                using (var stream = context.Response.Body)
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                    await stream.FlushAsync();
                }
    
                context.Response.ContentLength = buffer.Length;
            }
        }
    }
