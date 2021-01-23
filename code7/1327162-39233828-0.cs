    public interface ICurrentUser
        {
        /// <summary>
        ///     Gets the display name of the user.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; }
        /// <summary>
        ///     Gets the login name of the user. This is typically what the user would enter in the login screen, but may be
        ///     something different.
        /// </summary>
        /// <value>The name of the login.</value>
        string LoginName { get; }
        /// <summary>
        ///     Gets the unique identifier of the user. Typically this is used as the Row ID in whatever store is used to persist
        ///     the user's details.
        /// </summary>
        /// <value>The unique identifier.</value>
        string UniqueId { get; }
        /// <summary>
        ///     Gets a value indicating whether the user has been authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        bool IsAuthenticated { get; }
