    public class CustomerView
    {
        public readonly int Id;
        public readonly string Name;
        public readonly List<Orders> Orders;
    } 
    var customers = 
        from customer in Customers
        select new CustomerView() {
            Id = customer.Id,
            Name = customer.Name,
            Orders = customer.Orders.Where(x=>!x.IsDeleted).ToList()
        };
