	public class ApplicationUserStore : UserStore<ApplicationUser>
	{
		public ApplicationUserStore() : this(new IdentityDbContext())
        {
            DisposeContext = true;
        }
        public ApplicationUserStore(DbContext context) : base(context)
        {
        }
		
		public override Task<ApplicationUser> FindByIdAsync(string userId)
		{
			return GetUserAggregateAsync(u => u.Id.Equals(userId));
		}
		public override Task<ApplicationUser> FindByNameAsync(string userName)
		{
			return GetUserAggregateAsync(u => u.UserName.ToUpper() == userName.ToUpper());
		}
		Task<ApplicationUser> GetUserAggregateAsync(Expression<Func<ApplicationUser, bool>> filter)
		{
			return Users.Include(u => u.Roles)
				.Include(u => u.Claims)
				.Include(u => u.Logins)
				.Include(u => u.PublishingContexts)
				.FirstOrDefaultAsync(filter);
		}
	}
