	[ServiceContract]
	interface IProductService
	{
		[OperationContract]
		Task<Product> GetAsync(int id);
	}
	class ProductService : IProductService
	{
		ChannelFactory<IProductService> factory;
		public ProductService()
		{
			factory = new ChannelFactory<IProductService>("*");
		}
		public Task<Product> GetAsync(int id)
		{
			var channel = factory.CreateChannel();
			return channel.GetAsync(id);
		}
	}
	class ProductAPI : IProductService
	{
		public Task<Product> GetAsync(int id) => Task.FromResult(Get(id))
	}
