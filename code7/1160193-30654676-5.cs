    public class OrderAttribute : Attribute
    {
        public readonly int Order;
        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
