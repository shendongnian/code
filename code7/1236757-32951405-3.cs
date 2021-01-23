         public Task<DateTimeOffset> GetLockoutEndDateAsync(MyUser user)
        {
            //..
        }
    
        public Task SetLockoutEndDateAsync(MyUser user, DateTimeOffset lockoutEnd)
        {
            //..
        }
    
        public Task<int> IncrementAccessFailedCountAsync(MyUser user)
        {
            //..
        }
    
        public Task ResetAccessFailedCountAsync(MyUser user)
        {
            //..
        }
    
        public Task<int> GetAccessFailedCountAsync(MyUser user)
        {
            //..
        }
    
        public Task<bool> GetLockoutEnabledAsync(MyUser user)
        {
            //..
        }
    
        public Task SetLockoutEnabledAsync(MyUser user, bool enabled)
        {
            //..
        }
    }
