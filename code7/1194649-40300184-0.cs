        public class AuthorizeRolesAttribute : AuthorizeAttribute
        {
            public AuthorizeRolesAttribute(params string[] roles)
            {
                Roles = String.Join(",", roles);
            }
        }
