    public class EFAppContext : IdentityDbContext<ApplicationUser, CustomRole, int, 
        CustomUserLogin, CustomUserRole, CustomUserClaim>, 
        AppContext
    {
        if (!this.Database.Exists())
            this.Database.CreateIfNotExists();
        ...
    }
