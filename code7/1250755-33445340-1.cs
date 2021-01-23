    public class MyUserStore : IUserStore<User>, IUserPasswordStore<User>
    {
        private readonly MyDbContext _context;
        
        public MyUserStore(MyDbContext context)
        {
            _context=context;
        }
        
        public Task CreateAsync(AppUser user)
        {
            // implement your desired logic such as
            // _context.Users.Add(user);
        }
        public Task DeleteAsync(AppUser user)
        {
            // implement your desired logic
        }
        public Task<AppUser> FindByIdAsync(string userId)
        {
            // implement your desired logic
        }
        public Task<AppUser> FindByNameAsync(string userName)
        {
            // implement your desired logic
        }
        public Task UpdateAsync(AppUser user)
        {
            // implement your desired logic
        }
        public void Dispose()
        {
            // implement your desired logic
        }
        // Following 3 methods are needed for IUserPasswordStore
        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            // something like this:
            return Task.FromResult(user.Password_hash);
        }
        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.FromResult(user.Password_hash != null);
        }
        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            user.Password_hash = passwordHash;
            return Task.FromResult(0);
        }
    }
