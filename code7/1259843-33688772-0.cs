    public DbSet<Item> ItemSet {get;set;}
    public DbSet<Order> OrderSet {get;set;}
    public DbSet<ItemOrder> ItemOrders {get;set;}
    
    public class Item
    {
        public int Id {get;set;}
    }
    
    public class Order
    {
        public int Id {get;set;}
    }
    
    public class ItemOrder
    {
        [Key, Column(Order = 0)]
        public int ItemId {get;set;}
    
        [Key, Column(Order = 1)]
        public int OrderId {get;set;}
    }
