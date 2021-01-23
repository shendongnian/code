    public class UserPrincipal : ClaimsPrincipal
    {
        public UserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {
        }
        /// <summary>
        /// Full Name of current logged in user.
        /// </summary>
        public string FullName
        {
            get
            {
                return this.FindFirst("FullName").Value ?? string.Empty;
            }
        }
    }
