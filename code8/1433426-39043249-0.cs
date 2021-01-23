        public class ErrorHandler : ExceptionHandler
        {
            public override void Handle(ExceptionHandlerContext context)
            {
    
                context.Result = new TextPlainErrorResult()
                {
                    Request = context.ExceptionContext.Request,
                    Content = "Oops! Sorry! Something went wrong." + "Please contact support so we can try to fix it."
                };
            }
    
            private class TextPlainErrorResult : IHttpActionResult
            {
                public HttpRequestMessage Request { get; set; }
    
                public string Content { get; set; }
    
                public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, Content);
                    return Task.FromResult(response);
                }
            }
        }
