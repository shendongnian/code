    public class LoggingMiddleware
    {
        private AppFunc next;
    
        public LoggingMiddleware(MyDependency dependency)
        {
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
