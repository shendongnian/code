    public class CustomExceptionHandler : IExceptionHandler
    {    
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
          // Perform some form of logging
    
          context.Result = new ResponseMessageResult(new HttpResponseMessage
          {
            Content = new StringContent("An unexpected error occurred"),
            StatusCode = HttpStatusCode.InternalServerError
          });
    
          return Task.FromResult(0);
        }
    }
