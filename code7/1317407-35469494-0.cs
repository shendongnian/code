    public class YourDbContext : DbContext 
    {
         public YourDbContext() 
         {
              Configuration.UseDatabaseNullSemantics = true;
         }
         // DbSet declarations
    }
