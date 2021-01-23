    public class Product
    {
        public int ProductId { get; set; }
        //... other properties
        public virtual TblClass TblClass { get; set; }
        //... other properties
    }
    public class TblClass
    {
        //[Key, ForeignKey("Product")] <-- remove these attributes
        public int ProductId { get; set; }
        public string ClassName { get; set; }
        //.. other properties
        public virtual Product Product { get; set; }
        public int ClassOrder { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //other mappings
        modelBuilder.Entity<TblClass>()
            .HasKey(c => c.ProductId); 
        modelBuilder.Entity<Product>()
            .HasKey(c => c.ProductId); //consider to use database generated option
        //modelBuilder.Entity<Product>().Property(t => t.ProductId) 
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Product>()
            .HasOptional(f => f.TblClass)
            .WithRequired(s => s.Product);
    }
