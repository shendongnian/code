    public class MySqlContext : DbContext
    {
       public MySqlContext() : base("MySqlDB")
       {
          this.Configuration.LazyLoadingEnabled = false;
       }
    //DbSets....
    }
