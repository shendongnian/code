    public class Customer
    {
        public virtual List<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
