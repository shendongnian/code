FooExceptionHandler
        public class ApiExceptionHandler : ExceptionHandler
        {
            public override void Handle(ExceptionHandlerContext context)
            {
                var response = new Response<string>
                {
                    Code = StatusCode.Exception,
                    Message = $@"{context.Exception.Message},{context.Exception.StackTrace}"
                };
    
                context.Result = new CustomeErrorResult
                {
                    Request = context.ExceptionContext.Request,
                    Content = JsonConvert.SerializeObject(response),                
                };
            }
        }
    
        internal class CustomeErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }
    
            public string Content { get; set; }
    
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response =
                    new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(Content),
                        RequestMessage = Request
                    };
    
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Headers", "*");
    
                return Task.FromResult(response);
            }
        }
