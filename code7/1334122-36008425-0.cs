    public interface IOrdersRepository 
    {
        IEnumerable<Order> GetOrdersForCustomer(Guid customerId);
    }
    public class OrdersService : IOrdersService 
    {
        private readonly IOrdersRepository ordersRepository;
        // pass the orders repository that abstracts the database access
        // as a dependency, so your OrdersService can be tested in isolation
        public OrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository
        }
        public int GetOrdersCount(Customer customer) 
        {
            return ordersRepository.GetOrdersForCustomer(customer.Id).Count();
        }
        public decimal GetAllOrdersTotalSum(Customer customer)
        {
            return ordersRepository.GetOrdersForCustomer(customer.Id).Sum(order => order.TotalSum);
        }
    }
