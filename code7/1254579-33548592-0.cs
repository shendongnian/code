    public class GetHabitsIdentity: IdentityDbContext<GetHabitsUser, IdentityRole, string> where TUser : IdentityUser
    {
        public GetHabitsIdentity(DbContextOptions<GetHabitsIdentity> options)
            :base(options)
        {
        }        
    }
