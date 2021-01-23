    namespace YourNamespace {
        public class MyContext : DbContext{
            public DbSet<Test> Tests { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder){
                base.OnModelCreating(modelBuilder);
                modelBuilder.Configurations
                    .AddFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
    }
