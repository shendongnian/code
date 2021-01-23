    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context) // you can inject dependencies here
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await ResponseExceptionHelper.HandleExceptionAsync(context, ex);
            }
        }
    }
