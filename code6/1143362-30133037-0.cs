    public class MyOwinMiddleware : OwinMiddleware
    {
        public async Task Invoke(IOwinContext owinContext)
        {
            try
            {
                  await Next.Invoke(owinContext);
            }
            catch (TaskCanceledException)
            {
                 // Handle cancellation.
            }
            catch (Exception e)
            {
                 if (owinContext.Request.CallCancelled.IsCancellationRequested)
                 {
                     // Handle cancellation.
                 }
            }
        }
    }
