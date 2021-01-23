    public static class IdentityExtensions
    {
        public static string GetMasterUserId(this IIdentity identity)
        {
            if (identity == null)
                return null;
            return (identity as ClaimsIdentity).FirstOrNull(CustomClaimTypes.MasterUserId);
        }
        public static string GetMasterFullName(this IIdentity identity)
        {
            if (identity == null)
                return null;
            return (identity as ClaimsIdentity).FirstOrNull(CustomClaimTypes.MasterFullName);
        }
        internal static string FirstOrNull(this ClaimsIdentity identity, string claimType)
        {
            var val = identity.FindFirst(claimType);
            return val == null ? null : val.Value;
        }
    }
