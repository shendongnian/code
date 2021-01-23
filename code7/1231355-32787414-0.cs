      class Customer
    {
        public string Name;
        public string City;
        public Order[] Orders;
        public int Summary
        {
            get
            {
                int result = 0;
                foreach(Order order in this.Orders)
                {
                    result += order.Product * order.Quantity;
                }
                return result;
            }
        }
    }
