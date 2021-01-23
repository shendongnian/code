    public class Service1
    {
        private readonly Service2 _service2;
        public Service1(Service2 service2) {
            _service2 = service2;
        }
        public void Say()
        {
            Console.WriteLine("Hello, I m Service 1, let me call Service 2");
            _service2.Say();
        }
    }
