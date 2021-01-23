    public class MySecondDBContext : IdentityDbContext<ApplicationUser>
    {
        public SocialContext()
            : base("DefaultConnection")
        {
        }
