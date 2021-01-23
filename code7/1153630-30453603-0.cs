    /// <summary>
    ///     Returns true if the user is locked out
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> IsLockedOutAsync(TKey userId)
    {
        ThrowIfDisposed();
        var store = GetUserLockoutStore();
        var user = await FindByIdAsync(userId).WithCurrentCulture();
        if (user == null)
        {
            throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, Resources.UserIdNotFound,
                userId));
        }
        if (!await store.GetLockoutEnabledAsync(user).WithCurrentCulture())
        {
            return false;
        }
        var lockoutTime = await store.GetLockoutEndDateAsync(user).WithCurrentCulture();
        return lockoutTime >= DateTimeOffset.UtcNow;
    }
