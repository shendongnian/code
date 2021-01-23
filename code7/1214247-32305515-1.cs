    public class Service1 : IService
    {
        public ServiceTypes Type { get { return ServiceTypes.Service_One; } }
        public void DoWork()
        {
            return 1;
        }
    }
