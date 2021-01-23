    public IServiceImplementation GetServiceImplementation()
    {
        if (mode == "Live")
        {
            return new LiveServiceImplementation();
        }
        else if (mode == "Test")
        {
            return new TestServiceImplementation();
        }
        else
        {
            return null;
        }
    }
    public class LiveServiceImplementation : IServiceImplementation
    {
        public LiveServiceImplementation()
        {
            Mapper.CreateMap<LiveService.Product, Product>();
        }
        public Product GetProductUsingId(int productID)
        {
            LiveService.Service _service = new LiveService.Service();
            return Mapper.Map<LiveService.Product, Product>(_service.GetProduct(2638975));
        }
    }
    public class TestServiceImplementation : IServiceImplementation
    {
        public TestServiceImplementation()
        {
            Mapper.CreateMap<TestService.Product, Product>();
        }
        public Product GetProductUsingId(int productID)
        {
            TestService.Service _service = new TestService.Service();
            return Mapper.Map<TestService.Product, Product>(_service.GetProduct(2638975));
        }
    }
