    public class OrderHeader : Entity
    {
        public virtual ISet<OrderItem> Items { get; set; } // ISet here
    }
    
    public class OrderItem : Entity
    {
        public virtual decimal Price {get; set;}
        public virtual string ItemNumber {get; set;}
        public virtual OrderHeader Header {get; set;}
    }
    
    public class OrderHeaderMap : ClassMap<OrderHeader>
    {
        Id( e => e.Id).GeneratedBy.Native();
        HasMany(e => e.OrderItems).Inverse();
    }
    
    public class OrderItemMap : ClassMap<OrderItem>
    {
        Id(e => e.Id).GeneratedBy.Native();
        References(e => e.Header).Not.Nullable().AsSet(); // Explicit AsSet
    }
