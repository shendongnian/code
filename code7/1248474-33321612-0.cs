    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Orders> orders = new List<Orders>();
                List<CustomerOrders> customerOrders = new List<CustomerOrders>();
                var productOrders = orders.AsEnumerable()
                    .GroupBy(x => x.Product).ToList();
                foreach (var productOrder in productOrders)
                {
                    CustomerOrders newOrder = new CustomerOrders();
                    customerOrders.Add(newOrder);
                    newOrder.OrderId = productOrder.FirstOrDefault().Id;
                    newOrder.Product = productOrder.FirstOrDefault().Product;
                    newOrder.Count = productOrder.Count();
                }
            }
        }
        public class Orders
        {
            public Guid Id { get; set; }
            public Guid CustomerId { get; set; }
            public string Product { get; set; }
            public DateTime Date { get; set; }
        }
        public class CustomerOrders
        {
            public Guid OrderId { get; set; }
            public string Product { get; set; }
            public int Count { get; set; }
        }
    }
    ​
