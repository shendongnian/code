    public static class IdentityExtensions
    {
        public static string GetDisplayName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity);
    
            return claim.FindFirst("DisplayName");            
        }
    }
