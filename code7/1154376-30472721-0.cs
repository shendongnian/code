        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
    
            public CustomAuthorizeAttribute(string roleSelector)
            {
    
                Roles = GetRoles(roleSelector);
            }
    
            private string GetRoles(string roleSelector)
            {
                // Do something to get the dynamic list of roles instead of returning a hardcoded string
                return "Somerole";
            }
    }
    
