    public interface IService1 { }
    public interface IService2 { }
    public class Service1Impl : IService1 
    {
        public Service1Impl(HttpSessionStateBase ctx)
        {
           
        }
    
    }
    public class Service2Impl : IService2
    {
        public Service2Impl(IService1 service1)
        {
        }
    }
