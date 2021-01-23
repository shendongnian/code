    public class SeedDbInitializer : DropCreateDatabaseAlways<MyDbContext>
     {
         protected override void Seed(MyDbContext context)
         {
            context.Database.ExecuteSqlCommand(
                                               @"SELECT * INTO targetTable
                                                FROM[sourceserver].[sourcedatabase].[dbo].[sourceTable]"
                                               );
            base.Seed(context);
         }
      }
    
    public class MyDbContext : DbContext
     {
         public MyDbContext() : base("MyConnectionString")
         {
           Database.SetInitializer<MyDbContext>(new SeedDbInitializer());
         }
        public DbSet<User> Users { get; set; }
     }
