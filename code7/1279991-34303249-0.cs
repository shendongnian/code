    namespace Same.Namespace.FromOtherContextClass
    {
        public partial class Context : DbContext
        {
            static Context()
            {
                this.Configuration.LazyLoadingEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;
            }
        }
    }
