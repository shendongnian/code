    static void Main()
    {
        UnityContainer container = new UnityContainer();
        container.RegisterType<BrowseService, MyBrowseService>();
        container.RegisterType<Functions>(); //Need to register WebJob class
        var config = new JobHostConfiguration()
        {
            JobActivator = new UnityJobActivator(container)
        };
        var host = new JobHost(config);
        host.RunAndBlock();
    }
