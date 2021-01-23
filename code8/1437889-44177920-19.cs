    public class Consumer
    {
        private readonly Func<string, IService> serviceAccessor;
     
        public Consumer(Func<string, IService> serviceAccessor)
        {
            this.serviceAccessor = serviceAccesor;
        }
        
        public void UseServiceA()
        {
            //use serviceAccessor field to resolve desired type
            serviceAccessor("A").DoIServiceOperation();
        }
    }
