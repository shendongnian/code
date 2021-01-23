    public class Item
    {
      //...
    }
    public class YourContext: DbContext 
    {
        private string suffix="_2015";
        public SchoolDBContext(string _suffix): base() 
        {
           this.suffix=_suffix;
        }
        public DbSet<Item> Items{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             // Map an Entity Type to a Specific Table in the Database
             modelBuilder.Entity<Department>().ToTable("Item"+suffix);
            base.OnModelCreating(modelBuilder);
        }
    }
