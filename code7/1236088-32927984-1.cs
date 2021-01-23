    public virtual async Task<IdentityResult> CreateAsync(TUser user)
        {
            ThrowIfDisposed();
            await UpdateSecurityStampInternal(user);
            var result = await ValidateUserInternal(user);
            if (!result.Succeeded)
            {
                return result;
            }
            if (Options.Lockout.AllowedForNewUsers && SupportsUserLockout)
            {
                await GetUserLockoutStore().SetLockoutEnabledAsync(user, true, CancellationToken);
            }
            await UpdateNormalizedUserNameAsync(user);
            await UpdateNormalizedEmailAsync(user);
            return await Store.CreateAsync(user, CancellationToken);
        }
