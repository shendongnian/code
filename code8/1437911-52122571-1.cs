    public class MyController
    {
        private readonly IEnumerable<IService> _services;
        public MyController(IEnumerable<IService> services)
        {
            _services = services;
        }
        public void DoSomething()
        {
            var service = _services.Where(s => s.Name == "A").Single();
        }
    ...
    }
