        private ConcurrentDictionary<string, string> UserRehashed = 
            new ConcurrentDictionary<string, string>();
        private bool CanRehash(IdentityUser user)
        {
            return UserRehashed.TryAdd(user.Id, user.Id);
        }
        
        protected async override Task<bool> VerifyPasswordAsync(
            IUserPasswordStore<IdentityUser, string> store, IdentityUser user,
            string password)
        {
            var hash = await store.GetPasswordHashAsync(user).ConfigureAwait(false);
            var verifPassRes = PasswordHasher.VerifyHashedPassword(hash, password);
            if (verifPassRes == PasswordVerificationResult.SuccessRehashNeeded &&
                // avoid rehash loop.
                CanRehash(user))
            {
                var chPassRes = await this.ChangePasswordAsync(user.Id,
                    password, password).ConfigureAwait(false);
                if (!chPassRes.Succeeded)
                {
                    // throw or log, whatever.
                }
            }
            return verifPassRes != PasswordVerificationResult.Failed;
        }
