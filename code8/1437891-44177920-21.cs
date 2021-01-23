    public class Consumer
    {
        private readonly IService _aService;
     
        public Consumer(ServiceResolver serviceAccessor)
        {
            _aService = serviceAccessor("A");
        }
        
        public void UseServiceA()
        {
            _aService.DoTheThing();
        }
    }
