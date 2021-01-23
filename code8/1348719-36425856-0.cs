    public class MyRowViewModel
    {
        public MyRowViewModel(WebServiceOrders.Order order)
        {
            Order = order;
        }
    
        public Order { get; set; }
        public string Status { get; set; } //note you'll need to implement property notification
    }
