    class EfContext : DbContext
    {
        public EfContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        ...
