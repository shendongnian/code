    public class Price
    {
        public int Id { get; set; }
        public int PriceHistoryId { get; set; }
        public virtual PriceHistory PriceHistory { get; set; }
        public DateTime ActivationDate { get; set; }
        public decimal Value { get; set; }
    }
    public class PriceHistory
    {
        public int Id { get; set; }
        virtual public ICollection<Price> Prices { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Purchase Prices
		public virtual PriceHistory PurchasePriceHistory { get; set; }
        public int PurchasePriceHistoryId { get; set; }
        // Retail prices
        public virtual PriceHistory RetailPriceHistory { get; set; }
        public int RetailPriceHistoryId { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
	    public DbSet<Price> Prices { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // one price history has many prices: one to many:
            modelBuilder.Entity<PriceHistory>()
                .HasMany(p => p.Prices)
                .WithRequired(price => price.PriceHistory)
                .HasForeignKey(price => price.PriceHistoryId);
			// one product has 2 price histories, the used method is comparable
            // with the method user with two addresses
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.PurchasePriceHistory)
                .WithMany()
                .HasForeignKey(p => p.PurchasePriceHistoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.RetailPriceHistory)
                .WithMany()
                .HasForeignKey(p => p.RetailPriceHistoryId)
				.WillCascadeOnDelete(false);
        }
    }
