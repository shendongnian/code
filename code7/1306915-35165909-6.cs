		public class ElmahHandledErrorLoggerFilter : IExceptionFilter
		{
    		public void OnException(ExceptionContext context)
    		{
    			if (context.ExceptionHandled)
    				ErrorSignal.FromCurrentContext().Raise(context.Exception);
    		}
		}
