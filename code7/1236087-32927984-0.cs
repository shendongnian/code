    public virtual async Task<IdentityResult> CreateAsync(TUser user,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ThrowIfDisposed();
            await UpdateSecurityStampInternal(user, cancellationToken);
            var result = await ValidateUserInternal(user, cancellationToken);
            if (!result.Succeeded)
            {
                return result;
            }
            if (Options.Lockout.EnabledByDefault && SupportsUserLockout)
            {
                await GetUserLockoutStore().SetLockoutEnabledAsync(user, true, cancellationToken);
            }
            await UpdateNormalizedUserNameAsync(user, cancellationToken);
            await Store.CreateAsync(user, cancellationToken);
            return IdentityResult.Success;
        }
