    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public string ImagePath {get;set;}
        [InverseProperty("Product")]
        public virtual ICollection<Review> Reviews {get;set;}
    }
    [Table("Review")
    public class Review
    {
        [Key]
        public int ReviewId {get;set;}
        public int ProductId {get;set;}
        public string ReviewText {get;set;}
        [ForeignKey("ProductId")]
        public virtual Product Product {get;set;}
    }
    public class YourDbContext : DbContext
    {
        static YourDbContext()
        {
            //This prevents your database to be created or updated by EF
            //I prefer to keep the hand on my db
            Database.SetInitializer<YourDbContext>(null);
        }
        public YourDbContext()
            //The name value is the name of your connectionstring (in App.config or Web.config)
            //<configuration><connectionStrings><add ...
            : base("Name=YourDbContext"){}
        public DbSet<Product> Products {get;set;}
    }
