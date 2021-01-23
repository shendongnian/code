    /// <summary>
    ///     Encapsulates the concept of a 'current user' based on ASP.Net Identity.
    /// </summary>
    /// <seealso cref="MS.Gamification.DataAccess.ICurrentUser" />
    public class AspNetIdentityCurrentUser : ICurrentUser
        {
        private readonly IIdentity identity;
        private readonly UserManager<ApplicationUser, string> manager;
        private ApplicationUser user;
        /// <summary>
        ///     Initializes a new instance of the <see cref="AspNetIdentityCurrentUser" /> class.
        /// </summary>
        /// <param name="manager">The ASP.Net Identity User Manager.</param>
        /// <param name="identity">The identity as reported by the HTTP Context.</param>
        public AspNetIdentityCurrentUser(ApplicationUserManager manager, IIdentity identity)
            {
            this.manager = manager;
            this.identity = identity;
            }
        /// <summary>
        ///     Gets the display name of the user. This implementation returns the login name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName => identity.Name;
        /// <summary>
        ///     Gets the login name of the user.
        ///     something different.
        /// </summary>
        /// <value>The name of the login.</value>
        public string LoginName => identity.Name;
        /// <summary>
        ///     Gets the unique identifier of the user, which can be used to look the user up in a database.
        ///     the user's details.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueId
            {
            get
                {
                if (user == null)
                    user = GetApplicationUser();
                return user.Id;
                }
            }
        /// <summary>
        ///     Gets a value indicating whether the user has been authenticated.
        /// </summary>
        /// <value><c>true</c> if the user is authenticated; otherwise, <c>false</c>.</value>
        public bool IsAuthenticated => identity.IsAuthenticated;
        private ApplicationUser GetApplicationUser()
            {
            return manager.FindByName(LoginName);
            }
        }
