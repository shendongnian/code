    public class MyServiceConfig
    {
        public MyServiceConfig(string name)
        {
            // initialize
        }
    }
    public class MyService
    {
        public MyService(MyServiceConfig myServiceConfig)
        {
            // initialize
        }
    }
    services.AddInstance(new MyServiceConfig("Hello"));
    services.AddTransient<IMyService, MyService>();
