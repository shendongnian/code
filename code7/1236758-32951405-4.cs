        public class LockingUserManager<TUser, TKey> : UserManager<TUser, TKey>
        where TUser : class, IUser<TKey> 
        where TKey : IEquatable<TKey> 
    {
        private readonly IUserLockoutStore<TUser, TKey> _userLockoutStore;
    
        public LockingUserManager(IUserLockoutStore<TUser, TKey> store)
            : base(store)
        {
            if (store == null) throw new ArgumentNullException("store");
    
            _userLockoutStore = store;
        }
    
        public override async Task<TUser> FindAsync(string userName, string password)
        {
            var user = await FindByNameAsync(userName);
    
            if (user == null) return null;
    
            var isUserLockedOut = await GetLockoutEnabled(user);
    
            if (isUserLockedOut) return user;
    
            var isPasswordValid = await CheckPasswordAsync(user, password);
    
            if (isPasswordValid)
            {
                await _userLockoutStore.ResetAccessFailedCountAsync(user);
            }
            else
            {
                await IncrementAccessFailedCount(user);
    
                user = null;
            }
    
            return user;
        }
    
        private async Task<bool> GetLockoutEnabled(TUser user)
        {
            var isLockoutEnabled = await _userLockoutStore.GetLockoutEnabledAsync(user);
    
            if (isLockoutEnabled == false) return false;
    
            var shouldRemoveLockout = DateTime.Now >= await _userLockoutStore.GetLockoutEndDateAsync(user);
    
            if (shouldRemoveLockout)
            {
                await _userLockoutStore.ResetAccessFailedCountAsync(user);
    
                await _userLockoutStore.SetLockoutEnabledAsync(user, false);
    
                return false;
            }
    
            return true;
        }
    
        private async Task IncrementAccessFailedCount(TUser user)
        {
            var accessFailedCount = await _userLockoutStore.IncrementAccessFailedCountAsync(user);
    
            var shouldLockoutUser = accessFailedCount > MaxFailedAccessAttemptsBeforeLockout;
    
            if (shouldLockoutUser)
            {
                await _userLockoutStore.SetLockoutEnabledAsync(user, true);
    
                var lockoutEndDate = new DateTimeOffset(DateTime.Now + DefaultAccountLockoutTimeSpan);
    
                await _userLockoutStore.SetLockoutEndDateAsync(user, lockoutEndDate);
            }
        }
    }
