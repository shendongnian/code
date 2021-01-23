    public class OrderItem
    {
        public string ItemID;
    }
    
    public class OrderItems 
    {
       public OrderItem[] OrderItem;
    }
    
    public class OrderData
    {
        public int OrderID;
        public OrderItems[] OrderItems;
    }
