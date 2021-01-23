    public class Order
    {
        public Customer Customer { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
    }
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
    }
    Mapper.CreateMap<Order, OrderDto>();
    var order = new Order
    {
        Customer = new Customer
        {
            Name = "John Doe"
        }
    };
    OrderDto dto = Mapper.Map<Order, OrderDto>(order);
