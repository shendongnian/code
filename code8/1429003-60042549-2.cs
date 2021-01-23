    public partial class Model1 : DbContext
    {
        public Model1()
            : this(true)
        { }
        public Model1(bool enableLazyLoading = true)
            : base("name=Model1")
        {
            // You can also do this instead of the other lines
            //Database.SetInitializer<Model1>(new CreateDatabaseIfNotExists<Model1>());            
            //this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<Model1>(null);
            this.Configuration.ProxyCreationEnabled = false;
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.ProxyCreationEnabled = enableLazyLoading;
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.LazyLoadingEnabled = enableLazyLoading;
        }
