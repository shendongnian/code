    public class Service : IService
    {
        [Dependency]
        [Import]
        public IGenericRepo<ServiceObj> _serviceRepo { private get; set; }
        //...
    }
