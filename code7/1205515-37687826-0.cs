    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public IEnumerable<Order> Orders
        {
            get { return _orders.AsEnumerable(); }
        }
    
        private List<Order> _orders { get; set; }
    
        public Customer()
        {
            _orders = new List<Order>();
        }
    
        public static Expression<Func<Customer, ICollection<Order>>> OrderMapping
        {
            get { return c => c._orders; }
        }
    }
