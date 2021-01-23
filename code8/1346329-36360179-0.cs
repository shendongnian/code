     public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager, AppUser user, string authenticationType)
            {         
                var userIdentity = await manager.CreateIdentityAsync(user, authenticationType); 
                return userIdentity;
            }
