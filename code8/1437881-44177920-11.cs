    public class Consumer
    {
        private readonly Func<string, IService> _serviceAccessor;
     
        public Consumer(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccesor;
        }
        
        public void UseServiceA()
        {
            //use _serviceAccessor field to resolve desired type
            _serviceAccessor("A").DoIServiceOperation();
        }
    }
