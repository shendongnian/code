    public class ExceptionHanldingMiddleware : OwinMiddleware
    {
    	public override async Task Invoke(IOwinContext context)
    	{
    		try
    		{
    			await Next.Invoke(context);
    		}
    		catch (OperationCanceledException) when (context.Request.CallCancelled.IsCancellationRequested)
    		{
    			//swallow user-agent cancelling request.
    			_log.Trace($"client disconnected on request for: {context.Request.Path}.");
    		}
    		catch (Exception ex)
    		{
    			_log.Error(ex);
    			context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
    			context.Response.ReasonPhrase = "Internal Server Error";
    		}
    	}	
    }
