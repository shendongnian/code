    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        public MyContext()
            : base("myconn")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
    
        static MyContext()
        {
                DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<ModelOne> ModelOne { get; set; }
    
    }
