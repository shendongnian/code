    public virtual async Task<string> GetSecurityStampAsync(TKey userId)
    {
        ThrowIfDisposed();
        var securityStore = GetSecurityStore();
        var user = await FindByIdAsync(userId).WithCurrentCulture();
        if (user == null)
        {
            throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, Resources.UserIdNotFound,
                userId));
        }
        return await securityStore.GetSecurityStampAsync(user).WithCurrentCulture();
    }
