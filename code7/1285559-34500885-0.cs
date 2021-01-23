    public partial class Context : DbContext
    {
      public Context() : base("name=ContextConnection")
      {
        Configuration.LazyLoadingEnabled = false;
        Configuration.ProxyCreationEnabled = false;
      }
      ...
    }
