    using System.Data.Entity;
    public partial class ApplicationDbContext : DbContext
    {
       public static ApplicationDbContext Create()
       {
         var applicationDbContext = new ApplicationDbContext();
         applicationDbContext.Configuration.LazyLoadingEnabled = false;
         return applicationDbContext;
       }
    }
