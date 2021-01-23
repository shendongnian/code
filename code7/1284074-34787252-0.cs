        //A few simple tests
        [TestMethod]
        public void CheckThatOrderExist()
        {
            var service = new OrderServiceTestable();
            var order = service.GetOrderById(1);//This will be found in the list
            Assert.IsNotNull(order);
        }
    
        [TestMethod]
        public void CheckThatOrderDoesNotExist()
        {
            var service = new OrderServiceTestable();
            var order = service.GetOrderById(2);//This will not be found
            Assert.IsNull(order);
        }
        
        //Your data access layer
        public class OrderService
        {
            protected virtual IList<Order> OrderList { get; set; }
            public Order GetOrderById(int id)
            {
                return OrderList.SingleOrDefault(x => x.Id == id);
            }
        }
        //Order object
        public class Order
        {
            public int Id { get; set; }
        }
        //This class inherits the order service and over write the list of orders. An instance of this class is used in the tests.
        public class OrderServiceTestable : OrderService
        {
            protected new List<Order> OrderList;
            public OrderServiceTestable()
            {
                OrderList = new List<Order> {new Order {Id = 1}}; //This will overwrite the list of orders because its virtual in the order service class
            }
        }
