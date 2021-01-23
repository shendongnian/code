    class CustomUserStore: 
        IUserStore<User, int>,
        IUserPasswordStore<User, int>,
        IUserSecurityStampStore<User, int>
    {
        AppDbContext context = new AppDbContext();
        public Task<User> FindByIdAsync(int userId)
        {
            return context.Users.FindAsync(userId);
        }
        public Task<User> FindByNameAsync(string userName)
        {
            return context.Users.FirstOrDefaultAsync(u => u.Email == userName);
        }
        public Task CreateAsync(User user)
        {
            context.Entry(user).State = EntityState.Added;
            return context.SaveChangesAsync();
        }
        public Task UpdateAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }
        public Task DeleteAsync(User user)
        {
            context.Entry(user).State = EntityState.Deleted;
            return context.SaveChangesAsync();
        }
        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        public Task<string> GetSecurityStampAsync(User user)
        {
            return Task.FromResult(user.SecurityStamp);
        }
        public Task SetSecurityStampAsync(User user, string stamp)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
