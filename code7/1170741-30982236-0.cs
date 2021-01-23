    public class Context : DbContext
    {
        public Context() : base("EcommConnectionString")
        {
        }
    
        public DbSet<Entities.RLI_State> States { get; set; }
        public DbSet<Entities.RLI_Product> Products { get; set; }
        public DbSet<Entities.RLI_StateProduct_List> StateProductList { get; set; }
    }
