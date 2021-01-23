    public partial class Model1 : DbContext
    {
        public Model1()
            : this(true)
        { }
        public Model1(bool enableLazyLoading = true)
            : base("name=Model1")
        {
            // You can do this....
            //Database.SetInitializer<Model1>(new CreateDatabaseIfNotExists<Model1>());            
            //this.Configuration.LazyLoadingEnabled = false;
            // or this...
            Database.SetInitializer<Model1>(null);
            this.Configuration.ProxyCreationEnabled = false;
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.ProxyCreationEnabled = enableLazyLoading;
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.LazyLoadingEnabled = enableLazyLoading;
        }
        // All my tables and views are assigned to models, here...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
