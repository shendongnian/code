    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceBase
    {
    }
    
    public class TestService1 : ServiceBase, ITestService1
    {
    }
    
    public class TestService2 : ServiceBase, ITestService2
    {
    }
