    /// <summary>
    /// Exposes user related api which will automatically save changes to the UserStore
    /// </summary>
    public interface IIdentityManager : IIdentityManager<IIdentityUser> { }
    /// <summary>
    /// Exposes user related api which will automatically save changes to the UserStore
    /// </summary>
    public interface IIdentityManager<TUser> : IIdentityManager<TUser, string>
        where TUser : class, IIdentityUser<string> { }
    /// <summary>
    /// Exposes user related api which will automatically save changes to the UserStore
    /// </summary>
    public interface IIdentityManager<TUser, TKey> : IDisposable
        where TUser : class, IIdentityUser<TKey>
        where TKey : System.IEquatable<TKey> {
        Task<IIdentityResult> AddPasswordAsync(TKey userid, string password);
        Task<IIdentityResult> ChangePasswordAsync(TKey userid, string currentPassword, string newPassword);
        Task<IIdentityResult> ConfirmEmailAsync(TKey userId, string token);
        //...other code removed for brevity
    }
