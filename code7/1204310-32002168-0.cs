        public static class AuthConfig
        {
            public static void RegisterAuth()
            {
                WebSecurity.InitializeDatabaseConnection("ITAContext", "Users", "ID", "Login", autoCreateTables: true);
                if (!Roles.RoleExists(UserRights.Admin.ToString()))
                    Roles.CreateRole(UserRights.Admin.ToString());
                if (!Roles.RoleExists(UserRights.Moderator.ToString()))
                    Roles.CreateRole(UserRights.Moderator.ToString());
                if (!Roles.RoleExists(UserRights.User.ToString()))
                    Roles.CreateRole(UserRights.User.ToString());
            }
        }
