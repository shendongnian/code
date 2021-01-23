    public class GSDbContext : IdentityDbContext
    {
         public GSDbContext()
              : base("GSDbContext")
         {
         }
         public virtual IDbSet<ApplicationUser> Users { get; set; }
         //Nothing ELSE
    }
