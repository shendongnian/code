    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceBase
    {
        // TestService1 and TestService2  may call me 
        // but not WCF clients. I'm invisible
        public void SomeMethod () {}
    }
    
    public class TestService1 : ServiceBase, ITestService1
    {
        public void SomeServiceMethod1() { SomeMethod(); }
    }
    
    public class TestService2 : ServiceBase, ITestService2
    {
        public void SomeServiceMethod2() { SomeMethod(); }
    }
