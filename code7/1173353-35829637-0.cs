    // Usage example in Startup.cs
    public void Configure(IApplicationBuilder application)
    {
        application.UseIISPlatformHandler();
        application.UseStatusCodePagesWithReExecute("/error/{0}");
        application.UseHttpException();
        application.UseMvc();
    }
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseHttpException(this IApplicationBuilder application)
        {
            return application.UseMiddleware<HttpExceptionMiddleware>();
        }
    }
    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public HttpExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (HttpException httpException)
            {
                context.Response.StatusCode = httpException.StatusCode;
                if (httpException != null)
                {
                    var bytes = Encoding.UTF8.GetBytes(httpException.Message);
                    context.Response.Body = new MemoryStream(bytes);
                }
            }
        }
    }
    public class HttpException : Exception
    {
        private readonly int httpStatusCode;
        public HttpException(int httpStatusCode)
        {
            this.httpStatusCode = httpStatusCode;
        }
        public HttpException(HttpStatusCode httpStatusCode)
        {
            this.httpStatusCode = (int)httpStatusCode;
        }
        public HttpException(int httpStatusCode, string message) : base(message)
        {
            this.httpStatusCode = httpStatusCode;
        }
        public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            this.httpStatusCode = (int)httpStatusCode;
        }
        public HttpException(int httpStatusCode, string message, Exception inner) : base(message, inner)
        {
            this.httpStatusCode = httpStatusCode;
        }
        public HttpException(HttpStatusCode httpStatusCode, string message, Exception inner) : base(message, inner)
        {
            this.httpStatusCode = (int)httpStatusCode;
        }
        public int StatusCode { get { return this.httpStatusCode; } }
    }
