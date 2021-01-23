    public class SqlContext : DbContext
    {
       public SqlContext() : base("SqlDB")
       {
          Configuration.LazyLoadingEnabled = false;
       }
       //DbSets....
    }
