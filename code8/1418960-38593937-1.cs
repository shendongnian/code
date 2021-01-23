    public static class IdentityExtensions
    {
        public static string GetUserEmail(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue(ClaimTypes.Email);
            }
            return null;
        }
    }
