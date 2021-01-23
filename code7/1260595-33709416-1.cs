    public class EFAppContext : IdentityDbContext<ApplicationUser, CustomRole, int, 
        CustomUserLogin, CustomUserRole, CustomUserClaim>, 
        AppContext
    {
        using (var dbContextTransaction = this.Database.BeginTransaction())
        {
            try
            {
                if (!this.Database.Exists())
                    this.Database.CreateIfNotExists();
                dbContextTransaction.Commit();
            }
            catch
            {
                dbContextTransaction.Rollback();
            }
        }
        ...
    }
