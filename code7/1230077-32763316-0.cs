    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public ExceptionFilter(ILogger log, IClientExceptionFormatter exceptionFormatter)
        {
            ...
            _log = log;
            _exceptionFormatter = exceptionFormatter;
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            ...
            _log.Error(context.Exception);
            context.Response = new ExceptionJsonResponse(context.Exception, _exceptionFormatter);
        }
        ...
    }
