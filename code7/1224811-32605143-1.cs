    public class MyUserStore : UserStore<ApplicationUser>
    {     
        public MyUserStore(DbContext context)
            : base(context)
        {
             // other implementation for second DB
        }
        public override Task CreateAsync(ApplicationUser user)
        {
              // save Profile object to separate DB 
              _mySecondDB.Save(User.Id, user.Profile);
              return base.CreateAsync(user);
        }
        public override Task UpdateAsync(ApplicationUser user)
        {
            // same pattern as CreateAsync
        }
        public override Task DeleteAsync(ApplicationUser user)
        {
            // same pattern as CreateAsync
        }
        
        public override async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            var user = await base.FindByIdAsync(userId);
            user.Profile = _mySecondDB.FindProfileByUserId(userId);
            return user;
        }
        public override Task<ApplicationUser> FindByNameAsync(string userName)
        {
            // same pattern as FindByIdAsync
        }
    }
