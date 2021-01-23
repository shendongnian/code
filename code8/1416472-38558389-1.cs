    public static class IdentityExtensions
    {
        public static string GetNickName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("NickName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
