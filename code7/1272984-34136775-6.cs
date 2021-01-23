	// Client-specific implementation
	public class ClientOrderRepository : IRepository<Order>
	{
		private readonly IClientOrderService _service;
		public ClientOrderRepository(IClientOrderService clientOrderService)
		{
			_service = clientOrderService;
		}
		public void Save(Order order)
		{
			_service.Save(order);
		}
		
		public void Submit(Order order)
		{
			_service.Submit(order);
		}
	}
