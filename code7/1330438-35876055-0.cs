    public class ApplicationContext<TUser> : IdentityDbContext<TUser> 
      where TUser : IdentityUser
    {
      public static ApplicationContext()
      { 
        Database.SetInitializer<ApplicationContext>(new MyContextInitializer()); 
      }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        //entities builder and configuration
      }
    }
