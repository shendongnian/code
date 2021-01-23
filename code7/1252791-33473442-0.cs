    namespace Identity.Extensions
    {
        public static class UserExtensions()
        {
            public static List<string> Roles(this ClaimsIdentity identity)
            {
            return identity.Claims
                       .Where(c => c.Type == ClaimTypes.Role)
                       .Select(c => c.Value)
                       .ToList();
            }
        }
    }
