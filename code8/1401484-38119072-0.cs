     public class MyDbContext : DbContext
     {
       private readonly bool _isMigrationMode;
    
       public MyDbContext()
       {
         // This used by migration default and you can give the connection string in the command line.
         _isMigrationMode = true;
       }
  
       // isMigrationMode: I have give it here as an optional parameter, in case, if you want to create the migration from the code.
       public MyDbContext(string connectionString, bool isMigrationMode = false)
             : base("name=" + connectionString)
       {
         _isMigrationMode = isMigrationMode;
       }
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
         if (_isMigrationMode)
         {
           modelBuilder.Ignore<Hero>();
         }
    
         base.OnModelCreating(modelBuilder);
       }
    
       public DbSet<Mission> Missions { get; set; }
     }
