    public class OrderMapping:  EntityTypeConfiguration<Order>
    {
           public OrderMapping()
          {
             HasMany(o => o.Products).WithMany(p => p.Orders).Map(m =>
                {
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("ProductId");
                    m.ToTable("Order_Products");
                });
          }          
    }
