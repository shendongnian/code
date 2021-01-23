    // In Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(IService, ServiceA);
        services.AddScoped(IService, ServiceB);
        services.AddScoped(IService, ServiceC);
    }
    // Any class that uses the service(s)
    public class Consumer
    {
        private readonly IEnumerable<IService> _myServices;
        
        public Consumer(IEnumerable<IService> myServices)
        {
            _myServices = myServices;
        }
        public UseServiceA()
        {
            var serviceA = _myServices.FirstOrDefault(t => t.GetType() == typeof(ServiceA));
            serviceA.DoTheThing();
        }
        public UseServiceB()
        {
            var serviceB = _myServices.FirstOrDefault(t => t.GetType() == typeof(ServiceB));
            serviceB.DoTheThing();
        }
        public UseServiceC()
        {
            var serviceC = _myServices.FirstOrDefault(t => t.GetType() == typeof(ServiceC));
            serviceC.DoTheThing();
        }
    }
