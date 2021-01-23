        /// <summary>
        /// Check if the user was authenticated in the current request, or in a previous one
        /// </summary>
        public static bool IsUserAuthenticated(this IOwinContext context)
        {
            if (context.Request.User.Identity.IsAuthenticated)
                return true;
            if (null != context.Authentication.AuthenticationResponseGrant && null != context.Authentication.AuthenticationResponseGrant.Identity)
            {
                return context.Authentication.AuthenticationResponseGrant.Identity.IsAuthenticated;
            }
            return false;
        }
