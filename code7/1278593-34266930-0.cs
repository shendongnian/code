    public int StoreID { get; set; }
    public virtual Store Store { get; set; }
    public int Store1ID { get; set; }
    public virtual Store Store1 { get; set; }
    modelBuilder.Entity<Store>()
                .HasMany(m => m.Products)
                .WithRequired(m => m.Store);
    modelBuilder.Entity<Store>()
                .HasMany(m => m.Promotions)
                .WithRequired(m => m.Store1);
