    public class APIErrorHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var jsonResult = Json.Encode(new 
                                    {
                                        Message = new { Message = context.Exception.Message }, 
                                        Status = ... // whatever,
                                        Data = ... // whatever
                                    });
            context.Result = new ResponseMessageResult(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent(jsonResult) });
            return Task.FromResult(0);
        }
    }
