    namespace Export.Microsoft.Reports.Models
    {
        public class OrderModel
        {
            public Company Sender { get; set; }
            public Company Receiver { get; set; }
            public Company Other { get; set; }
            ...
            public OrderModel GetAllOrders()
            {
                ...
            }
        }
    }
