    public interface IService
    {
    }
    public class Service : IService
    {
    }
    public class MyClass
    {
        private readonly IService m_Service;
        public MyClass(IService service)
        {
            m_Service = service;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IService, Service>(); //We need to register interface-based dependency
            var my_class = container.Resolve<MyClass>(); //We can resolve class-based types without registering them explicitly
        }
    }
