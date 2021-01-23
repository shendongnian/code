    public class CustomUserStore : UserStore<ApplicationUser>
    {
        public CustomUserStore(ApplicationDbContext context) : base(context) { }
        
        protected override async Task<ApplicationUser> GetUserAggregateAsync(Expression<Func<ApplicationUser, bool>> filter)
        {
            var user = await base.GetUserAggregateAsync(filter);
            
            // if user is found but soft deleted then ignore and return null
            if (user != null && user.IsDeleted)
            {
                return null;
            }
            return user;
        }
    }
