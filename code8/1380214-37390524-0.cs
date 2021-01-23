    public class MyCustomExceptionHandler : ExceptionHandler
    {
        private readonly HttpConfiguration _configuration;
    
        public MyCustomExceptionHandler(HttpConfiguration config){
            _configuration = config;
        }
    
        public override void Handle(ExceptionHandlerContext context)
        {
            var formatters = _configuration.Formatters;
            var negotiator = _configuration.Services.GetContentNegotiator();
    
            context.Result = new NegotiatedContentResult<ErrorResponse>(HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = context.Exception.Message,
                    CustomProperty = "Something"
                }, negotiator, context.Request, formatters);
        }
    
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true; //your logic if you want only certain exception to be handled
        }
    }
    
    internal class ErrorResponse
    {
        public string Message { get; set; }
    
        public string CustomProperty { get; set; }
    }
