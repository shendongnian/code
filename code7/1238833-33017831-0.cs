    public class MyDbContext : DbContext {
    
            public MyDbContext()
                : base("connectionString") {
                Database.SetInitializer<MyDbContext>(null);
            }
    
            public virtual DbSet<Table1> Table1s { get; set; }
    
            public virtual DbSet<Table2> Table2s { get; set; }
    
            ...
    }
