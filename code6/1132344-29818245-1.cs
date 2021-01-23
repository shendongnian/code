        /// <summary>
        /// Check whether password of user cannot be changed.
        /// </summary>
        /// <param name="user">The DirectoryEntry object of user.</param>
        /// <returns>Return true if password cannot be changed else false.</returns>
        public static bool IsPasswordCannotBeChanged(DirectoryEntry user)
        {
            var isUserCantChangePass = false;
            try
            {
                // 1. Get SamAccountName
                var samAccountName = Convert.ToString(user.Properties["sAMAccountName"].Value);
                if (!string.IsNullOrEmpty(samAccountName))
                {
                    // 2. Prepare domain context
                    using (var domainContext = new PrincipalContext(ContextType.Domain, _domain, _domainUser, _domainPass))
                    {
                        // 3. Find user
                        var userPrincipal = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, samAccountName);
                        // 4. Check if user cannot change password
                        using (userPrincipal)
                            if (userPrincipal != null) isUserCantChangePass = userPrincipal.UserCannotChangePassword;
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.Write(exc);
            }
            return isUserCantChangePass;
        }
