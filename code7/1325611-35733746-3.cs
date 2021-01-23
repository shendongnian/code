    public interface IHelloService
    {
        void SayHello();
    }
    public class HelloService : IHelloService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    public class HelloServiceWrapper : IHelloService
    {
        public static readonly IHelloService Instance = new HelloServiceWrapper();
        private HelloServiceWrapper () {}
        
        private IHelloService _service;
        public void SayHello()
        {
            EnsureServiceAvailable();
            _service.SayHello(); 
        }
        private void EnsureServiceAvailable()
        {
            if(_service == null) {
                _service = new HelloService();
            }
        }
        private void HandleError()
        {
            _service = null;
        }
    }
