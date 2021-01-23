    public class ServiceProvider
    {
        private readonly Dictionary<Type, Action<object>> Handlers;
        public ServiceProvider()
        {
            var fooService = new FooService();
            var barService = new BarService();
            Handlers = new Dictionary<Type, Action<object>>
            {
                {typeof(FooRequestA), request => fooService.ProcessA((FooRequestA)request)},
                {typeof(FooRequestB), request => fooService.ProcessB((FooRequestB)request)},
                {typeof(BarRequest), request => barService.Process((BarRequest)request)}
            };
        }
        protected void ProcessRequest(object request)
        {
            Handlers[request.GetType()].Invoke(request);
        }
    }
