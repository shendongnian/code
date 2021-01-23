    public class FailedSetupMiddleware
    {
        private readonly Exception _exception;
        public FailedSetupMiddleware(Exception exception)
        {
            _exception = exception;
        }
        public Task Invoke(IOwinContext context, Func<Task> next)
        {
            var message = ""; // construct your message here
            return context.Response.WriteAsync(message);
        }
    }
