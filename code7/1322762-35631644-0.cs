    public class LogExceptionAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        private ILogger Logger { get; set; }
        public LogExceptionAttribute  (ILogger logger)
        {
            this.Logger  = logger;
        }
        
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                this.Logger.LogException(context.Exception);
            }
        }
    }
