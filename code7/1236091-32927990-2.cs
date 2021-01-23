    public virtual async Task<IdentityResult> CreateAsync(TUser user)
    {
            ThrowIfDisposed();
            await UpdateSecurityStampInternal(user).ConfigureAwait(false);
            var result = await UserValidator.ValidateAsync(user).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                return result;
            }
            if (UserLockoutEnabledByDefault && SupportsUserLockout)
            {
                await GetUserLockoutStore().SetLockoutEnabledAsync(user, true).ConfigureAwait(false);
            }
            await Store.CreateAsync(user).ConfigureAwait(false);
            return IdentityResult.Success;
    }
