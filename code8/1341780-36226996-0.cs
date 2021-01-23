    public class ProductByUser // Many to many table implemented as entity
    {
        public int ProductId  { get; set; }
        public int UserId  { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<ProductByUser>()
           .HasKey(c => new { c.ProductId , c.UserId });
    
       modelBuilder.Entity<Product>()
           .HasMany(c => c.ProductUsers)
           .WithRequired()
           .HasForeignKey(c => c.ProductId);
    
       modelBuilder.Entity<User>()
           .HasMany(c => c.ProductUsers)
           .WithRequired()
           .HasForeignKey(c => c.UserId);  
    }
