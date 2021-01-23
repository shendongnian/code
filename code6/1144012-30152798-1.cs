    public class LoggingMiddleware
    {
        private AppFunc next;
    
        public LoggingMiddleware(AppFunc next, MyDependency dependency)
        {
            this.next = next;
        }
        public void Initialize(AppFunc next)
        {
            this.next = next;
        }
    
        public async Task Invoke(IDictionary<string, object> environment)
        {
            await next.Invoke(environment);
        }
    }
