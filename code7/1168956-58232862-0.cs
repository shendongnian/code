    public static class WebApiConfiguration
    {
        public static void Register(HttpConfiguration config)
        {
            config.RegisterExceptionFilters();
        }
    }
    
    public static class HttpConfigurationFilterExtensions
    {
        public static HttpConfiguration RegisterExceptionFilters(this HttpConfiguration httpConfig)
        {
            httpConfig.Filters.Add(new CustomExceptionFilterAttribute());
    
            return httpConfig;
        }
    }
    
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CustomException)
            {
                context.Response = new HttpResponseMessage((HttpStatusCode)CustomHttpStatusCode.CustomCode);
            }
        }
    }
    
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(message)
        {
        }
    }
