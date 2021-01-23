    interface IService
    {
        String Code { get; }
    }
    class MyService : IService
    {
        public MyService() : this(DateTime.Now.Ticks.ToString())
        { }
        public MyService(String code)
        {
            this.Code = code;
        }
        public String Code { get; }
    }
    interface IOwner { }
    class Owner : IOwner
    {
        public Owner(IService service)
        {
            Console.WriteLine($"new owner for service {service.Code}");
        }
    }
