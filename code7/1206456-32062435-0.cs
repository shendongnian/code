    /// <summary>
    /// Add a user to a role
    /// 
    /// </summary>
    /// <param name="manager"/><param name="userId"/><param name="role"/>
    /// <returns/>
    public static IdentityResult AddToRole<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string role) where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException("manager");
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AddToRoleAsync(userId, role)));
    }
