    public class FooContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<BackendUser> BackendUsers { get; set; }
       public DbSet<ResellerContact> ResellerContacts { get; set; }
    }
