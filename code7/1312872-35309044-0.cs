    public class ServiceBase
    {
    }
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class TestService1 : ServiceBase, ITestService1
    {
    }
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class TestService2 : ServiceBase, ITestService2
    {
    }
