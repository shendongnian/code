    class OrderProxy : Order
    {
        public Order Order {get;}
        public OrderProxy(Order o)
        {
             this.Order = o;
        }
    }
