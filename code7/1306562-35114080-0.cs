    public class AuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Gets or sets the role the user is currently in.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }
    
        public bool CanCommandBeExecuted(ICatelCommand command, object commandParameter)
        {
            return true;
        }
    
        public bool HasAccessToUIElement(FrameworkElement element, object tag, object authenticationTag)
        {
            var authenticationTagAsString = authenticationTag as string;
            if (authenticationTagAsString != null)
            {
                if (authenticationTagAsString.Contains(Role))
                {
                    return true;
                }
            }
    
            return false;
        }
    }
