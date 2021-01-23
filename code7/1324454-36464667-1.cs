    public class CustomerService : ICustomerService
	{
			public List<Order> GetOrders()
			{
				UserPermissions.AssertRole(Role.Customer);
				// Code to get orders.
			}
	}
