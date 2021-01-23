    public class ApplicationContext : IdentityDbContext<TUser> 
      where TUser : IdentityUser
    {
      static ApplicationContext()
      { 
        Database.SetInitializer<ApplicationContext>(new MyContextInitializer()); 
      }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        //entities builder and configuration
      }
    }
