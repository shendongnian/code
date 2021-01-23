    public class GlobalExceptionHandler : IExceptionHandler
    
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message));
        }
    }
