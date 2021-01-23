    namespace Same.Namespace.FromOtherContextClass
    {
        public partial class Context : DbContext
        {
            public Context()
            {
                this.Configuration.LazyLoadingEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;
            }
        }
    }
