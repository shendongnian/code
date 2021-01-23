    public static class OrderDAL
    {
        public static Order Get(int key)
        {
            using (var context = new AppContext())
            {
                var order = context.Orders.Include(a => a.OrderDetails.Select(b => b.Information)).FirstOrDefault(a => a.Id == key);
                // Fills C.
                order.OrderDetailAdditionalInformation = order.OrderDetails.Select(b => b.Information).ToArray();
                // Hides information about B.
                order.OrderDetails = null;
                return order;
            }
        }
    }
    public class AppContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
    // A
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [NotMapped]
        public ICollection<OrderDetailAdditionalInformation> OrderDetailAdditionalInformation { get; set; }
    }
    // B, one A many B
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public string Item { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public OrderDetailAdditionalInformation Information { get; set; }
    }
    // C, one B one C
    public class OrderDetailAdditionalInformation
    {
        [ForeignKey("OrderDetail")]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Long { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
