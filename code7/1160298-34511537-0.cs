            public Task SetPasswordHashAsync(YourUser user, string passwordHash)
    		{
    			user.PasswordHash = passwordHash;
    			return Task.FromResult(0);
    		}
    		public Task<string> GetPasswordHashAsync(YourUser user)
    		{
    			return Task.FromResult<string>(user.PasswordHash);
    		}
    		public Task<bool> HasPasswordAsync(YourUser user)
    		{
    			return Task.FromResult<bool>(!String.IsNullOrEmpty(user.Password));
    		}
