    /// <summary>
    ///  Minimal interface for a user with an id of type <seealso cref="System.String"/>
    /// </summary>
    public interface IIdentityUser : IIdentityUser<string> { }
    /// <summary>
    ///  Minimal interface for a user
    /// </summary>
    public interface IIdentityUser<TKey>
        where TKey : System.IEquatable<TKey> {
        TKey Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        string EmailConfirmationToken { get; set; }
        string ResetPasswordToken { get; set; }
        string PasswordHash { get; set; }
    }
