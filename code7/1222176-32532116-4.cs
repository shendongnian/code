    public class MyMiddleware : OwinMiddleware
    {
        public MyMiddleware(OwinMiddleware next)
            : base(next)
        {}
    
        public override async Task Invoke(IOwinContext context)
        {
            var stopwatch = new Stopwatch();
    
            stopwatch.Start();
            await context.Response.WriteAsync("test");
            stopwatch.Stop();
    
            context.Response.Headers.Add("Elapsed-Time", new[] {stopwatch.ElapsedMilliseconds.ToString()});
        }
    }
