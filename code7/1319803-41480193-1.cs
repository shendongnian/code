    public class StatusCodeExceptionHandler
    {
        private readonly RequestDelegate request;
        public StatusCodeExceptionHandler(RequestDelegate next)
        {
            this.request = next;
        }
        public Task Invoke(HttpContext context) => this.InvokeAsync(context); // Stops VS from nagging about async method without ...Async suffix.
        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.request(context);
            }
            catch (StatusCodeException exception)
            {
                context.Response.StatusCode = (int)exception.StatusCode;
                context.Response.Headers.Clear();
            }
        }
    }
