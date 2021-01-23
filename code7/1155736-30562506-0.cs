        /// <summary>
        /// This is the static class that will hold the roles for all active users (active users 
        /// are those that have been using the website within the last 20 minutes).
        /// </summary>
        public static class MyRoles
        {
            /// <summary>
            /// This class holds your roles
            /// </summary>
            private class Principal
            {
                private DateTime lastAccess; // Our expiration timer
                private System.Security.Principal.GenericPrincipal principal; // Our roles
                public Principal(System.Security.Principal.GenericPrincipal principal)
                {
                    this.principal = principal;
                    this.lastAccess = DateTime.Now;
                }
                public System.Security.Principal.GenericPrincipal GenericPrincipal
                {
                    get
                    { 
                        // We reset our timer. It will expire 20 minutes from now. 
                        this.lastAccess = DateTime.Now;
                        return principal;
                    }
                }                                
                /// <summary>
                /// This tells us if a user has been active in the last 20 minutes
                /// </summary>
                public bool IsValid
                {
                    get
                    {
                        // Valid within 20 minutes from last call
                        return DateTime.Now <= this.lastAccess.AddMinutes(20);                        
                    }
                }
            }
            /// <summary>
            /// This will hold IDs and related roles
            /// </summary>
            private static Dictionary<string, Principal> ids = new Dictionary<string, Principal>();
            /// <summary>
            /// Method to retrieve roles for a given ID
            /// </summary>
            /// <param name="header">Our ID</param>
            /// <returns></returns>
            public static System.Security.Principal.GenericPrincipal GetRoles(string header)
            {
                if (ids.ContainsKey(header) && ids[header].IsValid)
                {
                    // We have roles for this ID
                    return ids[header].GenericPrincipal;
                }
                else
                {
                    // We don't have this ID (or it's expired) so get it from the web service
                    var id = new System.Security.Principal.GenericIdentity(header);
                    var principal = new System.Security.Principal.GenericPrincipal(id, new MyRoleProvider().GetRolesForUser(id.Name));
                    // Store roles
                    ids.Add(header, new Principal(principal));
                    return principal;
                }
            }            
        }
    
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // This is how we use our class
            var principal = MyRoles.GetRoles(Request.Headers["ceid"]);
        }
